using MongoDB.Driver.Core.WireProtocol.Messages;
using Resourceedge.Email.Api.Interfaces;
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

namespace Resourceedge.Appraisal.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISGClient client;
        EmailDispatcher dispatcher;
        public EmailSender(ISGClient _client, EmailDispatcher _dispatcher)
        {
            client = _client;
            dispatcher = _dispatcher;
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
                string filename = Path.GetFullPath("EmailTemplate/AppraisalNotification.html");
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

        public async Task<string> FormatEmailAppraisalScore(string Name, string score)
        {
            string[] message = GetEmailMessage(score);
            string Url = "https://resourceedge.herokuapp.com/";
            try
            {
                string body = "";
                string filename = Path.GetFullPath("EmailTemplate/emailTemplateScore.html");
                using (StreamReader sr = new StreamReader(filename))
                {
                    body = await sr.ReadToEndAsync();
                    sr.Close();
                }

                body = body.Replace("{FirstName}", Name);
                body = body.Replace("{score}", score);
                body = body.Replace("{Message}", message[0]);
                body = body.Replace("{Status}", message[1]);
                body = body.Replace("{Url}", Url);
                
                return body;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string[] GetEmailMessage(string scores)
        {
            double score = Convert.ToDouble(scores);
            string[] message = new string[2];

            if (score >= 4.5)
            {
                message[1]  = "Excellent";
                message[0] = "You did well, you achieved your targets and you have performed Excellently well. This is commendable and you are representing our values, Well done.";
            }
            else if (score < 4.5 && score >= 4)
            {
                message[1] = "Good";
                message[0] = "You did well, you achieved your targets and you have a good performance. This is commendable and you are representing our values, Well done.";
            }
            else if (score < 4 && score >= 3)
            {
                message[1] = "Average";
                message[0] = "You achieve average targets at all and you have performed well. This is acceptable and you can do better.";
            }
            else if (score < 3 && score >= 2)
            {
                message[1] = "Poor";
                message[0] = "You did not achieve your targets at all and you have performed poorly.This is totally unacceptable and doesn’t represent the values we hold dear.";
            }
            else if (score < 2)
            {
                message[1] = "Very Poor";
                message[0] = "You did not achieve your targets at all and you have performed poorly. This is totally unacceptable and doesn’t represent the values we hold dear.";
            }

            return message;
        }

        public Task<string> FormatEmail(string Name, string Url)
        {
            throw new NotImplementedException();
        }
    }
}
