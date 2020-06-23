using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Resourceedge.Appraisal.API.Helpers;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using Resourceedge.Worker.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class KeyResultAreaService : IKeyResultArea
    {
        public readonly IMongoCollection<KeyResultArea> Collection;
        public readonly IQueryable<KeyResultArea> QueryableCollection;
        private readonly ILogger<KeyResultArea> logger;
        private readonly ITokenAccesor tokenAccesor;
        private readonly AuthService authService;
        private readonly IEmailSender sender;
        private readonly HttpClient HttpClient;
        private readonly HttpClient AuthHttpClient;


        public KeyResultAreaService(IDbContext context, ILogger<KeyResultArea> _logger, IHttpClientFactory _httpClientFactory, ISGClient _client, ITokenAccesor _tokenAccesor, AuthService _authService, IEmailSender _sender)
        {
            Collection = context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
            QueryableCollection = Collection.AsQueryable<KeyResultArea>();
            logger = _logger;
            tokenAccesor = _tokenAccesor;
            authService = _authService;
            sender = _sender;
            HttpClient = _httpClientFactory.CreateClient("EmployeeService");
            AuthHttpClient = _httpClientFactory.CreateClient("Auth");
            //Collection.UpdateMany(Builders<KeyResultArea>.Filter.Where(x=>x.EmployeeId !=0 ), Builders<KeyResultArea>.Update.Unset(x => x.AppraiserDetails.Type));
            //HttpClient.SetBearerToken(tokenAccesor.TokenResponse.AccessToken);
            //AuthHttpClient.SetBearerToken(tokenAccesor.TokenResponse.AccessToken);
        }

        public async Task<IEnumerable<KeyResultArea>> Get(int? PageSize, int? PageNumber)
        {
            return await Collection.AsQueryable().Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value).ToListAsync();
        }

        public void Insert(KeyResultArea entity)
        {
            if (entity != null)
            {
                Collection.InsertOne(entity);
            }
        }

        public async Task<KeyResultArea> QuerySingle(ObjectId Id)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(a => a.Id == Id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<KeyResultArea> QuerySingleByKeyOutcome(ObjectId Id)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(a => a.keyOutcomes.Any(r => r.Id == Id));
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public IEnumerable<KeyResultArea> QuerySingle(Func<IEnumerable<KeyResultArea>, bool> func)
        {
            throw new NotImplementedException();
        }

        public KeyResultArea Update(ObjectId Id, KeyResultAreaForUpdateMainDto entity)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id);
            var aa = entity.ToBsonDocument();
            var update = new BsonDocument("$set", aa);
            Collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return null;
        }

        public async void Delete(ObjectId id)
        {
            if (id != null)
            {
                await Collection.FindOneAndDeleteAsync(a => a.Id == id);
            }
        }

        public async Task<KeyResultArea> DeleteKeyOutcome(ObjectId id, KeyResultArea entity)
        {
            if (id != null)
            {
                var keyoutcome = entity.keyOutcomes.FirstOrDefault(a => a.Id == id);
                var filter = Builders<KeyResultArea>.Filter.Eq("keyOutcomes.Id", id);
                var update = Builders<KeyResultArea>.Update.Pull("keyOutcomes", keyoutcome);

                var result = await Collection.FindOneAndUpdateAsync<KeyResultArea>(filter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });

                return result;
            }

            return null;
        }

        public async void Delete(KeyResultArea entity)
        {
            await Collection.FindOneAndDeleteAsync(Builders<KeyResultArea>.Filter.Where(r => r == entity));
        }

        public async Task<KeyResultArea> QuerySingleByUserId(ObjectId id, int UserId)
        {
            if (id != null && UserId != 0)
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == id && r.EmployeeId == UserId);
                var result = await Collection.FindAsync(filter);

                return result.FirstOrDefault();
            }
            return null;
        }

        public async Task<bool> AddKeyOutcomes(IEnumerable<KeyResultArea> entity)
        {
            Collection.InsertMany(entity);
            var superviorsAndClaims = new Dictionary<string, List<Claim>>();

            superviorsAndClaims = FormatHodDetailsForClaims(entity, superviorsAndClaims);
            superviorsAndClaims = FormatAppraiserForClaims(entity, superviorsAndClaims);

            var result = await authService.AddUserClaimsByEmail(superviorsAndClaims);
            //var result2 = await SendCliamsToEmployeeSystemForSupervisors(superviorsAndClaims);
            return true;
        }

        public Dictionary<string, List<Claim>> FormatHodDetailsForClaims(IEnumerable<KeyResultArea> entity, Dictionary<string, List<Claim>> superviorsAndClaims)
        {
            foreach (var resultArea in entity)
            {
                if (resultArea.HodDetails.Email != null)
                {
                    if (superviorsAndClaims.ContainsKey(resultArea.HodDetails.Email))
                    {
                        //Add claims for Supervisor
                        var currentClaims = superviorsAndClaims[resultArea.HodDetails.Email];
                        var exisitingClam = currentClaims.FirstOrDefault(X => X.Value == "hod");
                        if (exisitingClam == null)
                        {
                            superviorsAndClaims[resultArea.HodDetails.Email].Add(new Claim("privilege_appraisal", "hod"));
                        }
                    }
                    else
                    {
                        superviorsAndClaims[resultArea.HodDetails.Email] = new List<Claim> { new Claim("privilege_appraisal", "hod") };
                    }
                }
            }
            return superviorsAndClaims;
        }



        public Dictionary<string, List<Claim>> FormatAppraiserForClaims(IEnumerable<KeyResultArea> entity, Dictionary<string, List<Claim>> superviorsAndClaims)
        {
            foreach (var resultArea in entity)
            {
                if (resultArea.AppraiserDetails.Email != null)
                {
                    if (superviorsAndClaims.ContainsKey(resultArea.AppraiserDetails.Email))
                    {
                        //Add claims for Supervisor
                        var currentClaims = superviorsAndClaims[resultArea.AppraiserDetails.Email];
                        var exisitingClam = currentClaims.FirstOrDefault(X => X.Value == "appraiser");
                        if (exisitingClam == null)
                        {
                            superviorsAndClaims[resultArea.AppraiserDetails.Email].Add(new Claim("privilege_appraisal", "appraiser"));
                        }
                    }
                    else
                    {
                        superviorsAndClaims[resultArea.AppraiserDetails.Email] = new List<Claim> { new Claim("privilege_appraisal", "appraiser") };
                    }
                }

            }
            return superviorsAndClaims;
        }


        public void AddKeyOutcomes(KeyResultArea entity)
        {
            Collection.InsertOne(entity);
        }

        public IEnumerable<KeyResultArea> GetPersonalkpis(int userId, string resultId = null)
        {
            if (resultId != null)
            {
                ObjectId Id = new ObjectId(resultId);
                return QueryableCollection.Where(x => x.EmployeeId == userId && x.Id == Id).ToList();
            }

            return QueryableCollection.Where(x => x.EmployeeId == userId).ToList();
        }



        public async Task<KeyResultArea> Update(ObjectId Id, KeyResultArea entity)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id);
            var update = new BsonDocument("$set", entity.ToBsonDocument());
            var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });
            return result;
        }

        public async Task<KeyResultArea> QuerySingleUserKeyOutcome(ObjectId id, ObjectId outcomeId, int UserId)
        {
            if (id != null && UserId != 0)
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == id && r.EmployeeId == UserId && r.keyOutcomes.Any(a => a.Id == outcomeId));
                var result = await Collection.FindAsync(filter);

                return result.FirstOrDefault();
            }
            return null;
        }

        public async Task<long> UpdateKeyOutcome(ObjectId Id, ObjectId outcomeId, int UserId, KeyOutcomeForUpdateDto entity)
        {
            entity.keyOutcomes.Id = outcomeId;
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id && r.EmployeeId == UserId && r.keyOutcomes.Any(a => a.Id == outcomeId));
            var bsonElement = entity.keyOutcomes.ToBsonDocument();
            var update = Builders<KeyResultArea>.Update.Set("keyOutcomes.$", bsonElement);
            var result = await Collection.UpdateOneAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task<KeyResultArea> HodApproval(int empId, int memberId, ObjectId keyResultAreaId, string whoami, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.EmployeeId == memberId && r.Id == keyResultAreaId && (r.HodDetails.EmployeeId == empId || r.AppraiserDetails.EmployeeId == empId));
                var oldKeyResultArea = Collection.Find(filter).FirstOrDefault();
                if (oldKeyResultArea != null)
                {
                    if (oldKeyResultArea.AppraiserDetails.EmployeeId == empId)
                    {
                        oldKeyResultArea.Status.Appraiser = entity.Approve;
                    }
                    else if (oldKeyResultArea.HodDetails.EmployeeId == empId && whoami == "HOD")
                    {
                        oldKeyResultArea.Status.Hod = entity.Approve;
                        oldKeyResultArea.Status.IsAccepted = entity.Approve;
                    }
                    else
                    {
                        oldKeyResultArea.SetActive();
                    }

                    var newKeyResultArea = oldKeyResultArea.ToBsonDocument();

                    var update = new BsonDocument("$set", newKeyResultArea);
                    var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });

                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                //throw ex.InnerException;
                logger.LogError("update of appraisal configuration failed", ex);
                return null;
            }
        }

        public async Task<long> EmployeeApproval(int empId, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.EmployeeId == empId && r.Year == DateTime.Now.Year);

                var oldKeyResultArea = Collection.Find(filter).ToList();
                oldKeyResultArea.ForEach(async x =>
                {
                    x.Status.Employee = (x.Status.Appraiser.Value == true) ? entity.Approve : null;
                    x.SetActive();

                    var newKeyResultArea = x.ToBsonDocument();
                    var update = new BsonDocument("$set", newKeyResultArea);

                    var newfilter = Builders<KeyResultArea>.Filter.Where(a => a.Id == x.Id);

                    //var update = Builders<KeyResultArea>.Update.Set("Status.Employee", entity.Approve);
                    var result = await Collection.FindOneAndUpdateAsync(newfilter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });

                });

                return oldKeyResultArea.Count();
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                return 0;
            }
        }

        public IEnumerable<KeyResultArea> GetKeyResultAreasForAppraiser(int appraiserId, int employeeId)
        {
            var result = QueryableCollection.Where(x => x.HodDetails.EmployeeId == appraiserId || x.AppraiserDetails.EmployeeId == appraiserId && x.EmployeeId == employeeId).ToList();
            return result;
        }

        public async void SendApprovalNotification(IEnumerable<KeyResultArea> keyAreas)
        {
            string subject = "Approve Key Result Area ";
            string message = "has sumbitted one or more key result area, kindly review and act on it";
            string title = "Key Result Area(KRA) For Approval";
            string htmlContent = "";
            string textContent = "";

            var comparer = EdgeComparer.Get<EmailObject>((x, y) => x.ReceiverEmailAddress == y.ReceiverEmailAddress);
            List<EmailObject> emailObj = keyAreas.Select(x => new EmailObject() { ReceiverEmailAddress = x.HodDetails.Email, ReceiverFullName = x.HodDetails.Name }).ToList();

            var distinctEmailObject = emailObj.Distinct(comparer).Select(x => x).ToList();
            var employee = await GetEmployee(keyAreas.FirstOrDefault().EmployeeId);
            EmailDtoForMultiple emailDtos = new EmailDtoForMultiple()
            {
                PlainTextContent = textContent,
                HtmlContent = htmlContent,
                EmailObjects = distinctEmailObject
            };

            var result = sender.SendMultipleEmail(subject, employee.FullName, emailDtos, message, title);

        }

        public async Task<OldEmployeeForViewDto> GetEmployee(int empId)
        {
            HttpClient.SetBearerToken(tokenAccesor.TokenResponse.AccessToken);
            var response = await HttpClient.GetAsync($"api/employee/employeeId/{empId}");
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<OldEmployeeForViewDto>(content, options);

                return result;
            }
            return null;
        }

        public async Task<bool> SendCliamsToEmployeeSystemForSupervisors(Dictionary<string, List<Claim>> supervisorsAndClaims)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(supervisorsAndClaims);
                var result = await AuthHttpClient.PostAsync("api/auth/external", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HasUploadedEpa(int employeeId)
        {
            var year = DateTime.Now.Year;
            return QueryableCollection.Any(x => x.EmployeeId == employeeId && x.Year == year);
        }


        //public async Task<IEnumerable<NameEmailWithType>> GetAllSupervisorsForClaims()
        //{
        //    var comparer = EdgeComparer.Get<NameEmailWithType>((x, y) => x.EmployeeId == y.EmployeeId && x.Email.ToLower() == y.Email.ToLower());
        //    var CombinedDetails = new List<NameEmailWithType>() { };
        //    var Hods = QueryableCollection.Select(X => new NameEmailWithType { Email = X.HodDetails.Email, EmployeeId = X.HodDetails.EmployeeId, Name = X.HodDetails.Name, Type = "hod" })
        //        .ToList().Distinct(new NameEmailComparer());
        //    var supervisors = QueryableCollection.Select(X => new NameEmailWithType { Email = X.AppraiserDetails.Email, EmployeeId = X.AppraiserDetails.EmployeeId, Name = X.AppraiserDetails.Name, Type = "appraiser" })
        //        .ToList().Distinct(new NameEmailComparer());

        //    CombinedDetails.AddRange(Hods);
        //    CombinedDetails.AddRange(supervisors);

        //    var superviorsAndClaims = new Dictionary<string, List<Claim>>();


        //    var KeyResultAreaFormat = new List<KeyResultArea>();

        //    foreach (var item in Hods)
        //    {
        //        KeyResultAreaFormat.Add(new KeyResultArea { HodDetails = item });
        //    }
        //    foreach (var item in supervisors)
        //    {
        //        KeyResultAreaFormat.Add(new KeyResultArea { AppraiserDetails = item });
        //    }

        //    KeyResultAreaFormat.RemoveAll(x => x == null);

        //    superviorsAndClaims = FormatHodDetailsForClaims(KeyResultAreaFormat, superviorsAndClaims);
        //    superviorsAndClaims = FormatAppraiserForClaims(KeyResultAreaFormat, superviorsAndClaims);

        //    await authService.AddUserClaimsByEmail(superviorsAndClaims);

        //    return CombinedDetails;
        //}
    }
}
