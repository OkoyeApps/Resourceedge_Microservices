using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.Services;
using Resourceedge.Email.Api.SGridClient;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Helpers
{
    public class EmailSender
    {
        private readonly ISGClient client;
        EmailDispatcher dispatcher;
        public EmailSender(ISGClient _client)
        {
            client = _client;
            dispatcher = new EmailDispatcher(client);
        }

        public async Task<HttpStatusCode> SendToSingleEmployee(string Subject, SingleEmailDto singleEmail)
        {     
            return await dispatcher.SendSingleEmail(Subject, singleEmail);
        }

        public async Task<HttpStatusCode> SendToMultipleEmail(string subject, EmailDtoForMultiple emailDtos)
        {
            var emails = emailDtos.EmailObjects.Select(x => new EmailAddress(x.ReceiverEmailAddress, x.ReceiverFullName)).ToList();
            string textContent = emailDtos.PlainTextContent;
            string htmlContent = emailDtos.HtmlContent;

            return await dispatcher.SendSingleMailToMultipleEmail(subject, textContent, htmlContent, emails);

        }


        public async Task<HttpStatusCode> SendMultipleEmail(string subject, string employeeName, EmailDtoForMultiple emailDtos, string message, string title)
        {
            try
            {
                var emails = emailDtos.EmailObjects.Select(x => new EmailAddress(x.ReceiverEmailAddress, x.ReceiverFullName)).ToList();
                string url = "https://resourceedge.herokuapp.com";

                emails.Add(new EmailAddress("Nwabugwu.akomas@tenece.com ", "Nwabugwu Akomas"));
                
                foreach (var item in emails)
                {
                    SingleEmailDto singleEmail = new SingleEmailDto()
                    {
                        PlainTextContent = emailDtos.PlainTextContent,
                        HtmlContent = await FormatEmail(employeeName, item.Name, message, title,url),
                        ReceiverEmailAddress = item.Email,
                        ReceiverFullName = item.Name
                    };

                    if(singleEmail.HtmlContent == null)
                    {
                        singleEmail.HtmlContent = @$"<p>{employeeName} has added you as a supervisor, kindly login to resourceedge and approve his EPA.</p>";
                    }

                     await dispatcher.SendSingleEmail(subject, singleEmail);
                }
                return HttpStatusCode.OK;        
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

        public async Task<string> FormatEmail(string Name, string supervisor,string message, string title,string Url)
        {
            //var mailMessage = new MailMessage();
            try
            {
                string body = "";
                var AppDomains = AppDomain.CurrentDomain.FriendlyName;
                string filename = Path.GetFullPath("EmailTemplate\\AppraisalNotification.html");
                using (StreamReader sr = new StreamReader(filename))
                {
                    body = await sr.ReadToEndAsync();
                }

                body = body.Replace("{FullName}", Name);
                body = body.Replace("{GroupName}", "RESOURCE EDGE");
                body = body.Replace("{Supervisor}", supervisor);
                body = body.Replace("{Message}", message);
                body = body.Replace("{Title}", title);
                body = body.Replace("{Link}", Url);

                return body;
            }
            catch(Exception ex)
            {
                return null;
            }
          
        }

    }
}
