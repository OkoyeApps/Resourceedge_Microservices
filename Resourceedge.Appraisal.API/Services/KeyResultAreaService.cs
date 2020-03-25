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
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Services
{
    public class KeyResultAreaService : IKeyResultArea
    {
        public readonly IMongoCollection<KeyResultArea> Collection;
        public readonly IQueryable<KeyResultArea> QueryableCollection;
        private readonly ILogger<KeyResultArea> logger;
        private readonly ISGClient client;
        private readonly HttpClient HttpClient; 
        EmailSender sender;


        public KeyResultAreaService(IDbContext context, ILogger<KeyResultArea> _logger, IHttpClientFactory _httpClientFactory, ISGClient _client)
        {
            Collection = context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
            QueryableCollection = Collection.AsQueryable<KeyResultArea>();
            logger = _logger;
            client = _client;
            HttpClient = _httpClientFactory.CreateClient("EmployeeService");
            sender = new EmailSender(client);
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

        public IEnumerable<KeyResultArea> QuerySingle(Func<IEnumerable<KeyResultArea>, bool> func)
        {
            throw new NotImplementedException();
        }

        public KeyResultArea Update(ObjectId Id, KeyResultAreaForUpdateMainDto entity)
        {
            var filter = Builders<KeyResultArea>.Filter.Where(r => r.Id == Id);
            var aa = entity.ToBsonDocument();
            var update = new BsonDocument("$set", aa);
            Collection.UpdateOne(filter, update);

            return null;
        }

        public async void Delete(ObjectId id)
        {
            if (id != null)
            {
                await Collection.FindOneAndDeleteAsync(a => a.Id == id);
            }
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

        public void AddKeyOutcomes(IEnumerable<KeyResultArea> entity)
        {
            Collection.InsertMany(entity);
            return;
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

        public Task<KeyResultArea> Update(ObjectId Id, KeyResultArea entity)
        {
            throw new NotImplementedException();
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
            //var update = new BsonDocument("$set", entity.ToBsonDocument());
            var bsonElement = entity.keyOutcomes.ToBsonDocument();

            var update = Builders<KeyResultArea>.Update.Set("keyOutcomes.$", bsonElement);

            var result = await Collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount;
        }

        public async Task<KeyResultArea> HodApproval(int empId, ObjectId keyResultAreaId, string whoami, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.EmployeeId == empId && r.Id == keyResultAreaId);
                var oldKeyResultArea = Collection.Find(filter).FirstOrDefault();

                if (whoami == "HOD")
                {
                    oldKeyResultArea.Status.Hod = entity.Approve;
                }
                else
                {
                    oldKeyResultArea.Status.IsAccepted = entity.Approve;
                    oldKeyResultArea.SetActive();
                }
                var newKeyResultArea = oldKeyResultArea.ToBsonDocument();

                var update = new BsonDocument("$set", newKeyResultArea);
                var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                return null;
            }
        }

        public async Task<KeyResultArea> EmployeeApproval(int empId, ObjectId keyResultAreaId, StatusForUpdateDto entity)
        {
            try
            {
                var filter = Builders<KeyResultArea>.Filter.Where(r => r.EmployeeId == empId && r.Id == keyResultAreaId);

                var oldKeyResultArea = Collection.Find(filter).FirstOrDefault();
                oldKeyResultArea.Status.Employee = entity.Approve;
                var newKeyResultArea = oldKeyResultArea.ToBsonDocument();

                var update = new BsonDocument("$set", newKeyResultArea);
                var result = await Collection.FindOneAndUpdateAsync(filter, update, options: new FindOneAndUpdateOptions<KeyResultArea> { ReturnDocument = ReturnDocument.After });

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("update of appraisal configuration failed", ex);
                return null;
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

            List<EmailObject> emailObj = keyAreas.Select( x => new EmailObject() { ReceiverEmailAddress = x.HodDetails.Email, ReceiverFullName = x.HodDetails.Name}).ToList();
            emailObj.AddRange(keyAreas.Select(x => new EmailObject() { ReceiverEmailAddress = x.AppraiserDetails.Email, ReceiverFullName = x.AppraiserDetails.Name }).ToList());

            var employee = await GetEmployee(keyAreas.FirstOrDefault().EmployeeId);
            string htmlContent = "";
             string textContent = "";
            EmailDtoForMultiple emailDtos = new EmailDtoForMultiple()
            {
                PlainTextContent = textContent,
                HtmlContent = htmlContent,
                EmailObjects = emailObj
            };        
            
            var result = sender.SendMultipleEmail(subject, employee.FullName, emailDtos);
           
        }

        public async Task<OldEmployeeForViewDto> GetEmployee(int empId)
        {

            var response = await HttpClient.GetAsync($"api/employee/employeeId/{empId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<OldEmployeeForViewDto>(content, options);

                return result;
            }

            return null;
        }
    }
}
