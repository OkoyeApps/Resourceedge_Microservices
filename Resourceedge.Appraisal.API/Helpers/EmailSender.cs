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
        EmailSender sender;

        private readonly ISGClient client;
        EmailDispatcher dispatcher;
        public EmailSender(ISGClient _client)
        {
            client = _client;
            dispatcher = new EmailDispatcher(client);
            sender = new EmailSender(client);
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


        public async Task<HttpStatusCode> SendMultipleEmail(string subject, string employeeName, EmailDtoForMultiple emailDtos)
        {
            try
            {
                var emails = emailDtos.EmailObjects.Select(x => new EmailAddress(x.ReceiverEmailAddress, x.ReceiverFullName)).ToList();
                emails.Add(new EmailAddress("kingdav.ndcdavison@gamil.com", "Nwabugwu Akomas"));

                foreach (var item in emails)
                {
                    SingleEmailDto singleEmail = new SingleEmailDto()
                    {
                        PlainTextContent = emailDtos.PlainTextContent,
                        HtmlContent = await sender.FormatEmail(employeeName, item.Name),
                        ReceiverEmailAddress = item.Email,
                        ReceiverFullName = item.Name
                    };

                     await dispatcher.SendSingleEmail(subject, singleEmail);

                }
                return HttpStatusCode.OK;        
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public async Task<string> FormatEmail(string Name, string supervisor)
        {
            //var mailMessage = new MailMessage();
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
            //body = body.Replace("{Url}", Url);
            return body;
        }

    }
}
