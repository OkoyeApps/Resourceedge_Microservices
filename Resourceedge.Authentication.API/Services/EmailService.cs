using Resourceedge.Email.Api.Interfaces;
using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.Services;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.Services
{
    public class EmailService : IEmailSender
    {
        private readonly ISGClient client;
        EmailDispatcher dispatcher;
        public EmailService(ISGClient _client, EmailDispatcher _dispatcher)
        {
            client = _client;
            dispatcher = _dispatcher;
        }

        public async Task<HttpStatusCode> SendToSingleEmployee(string Subject, SingleEmailDto singleEmail)
        {
            return await dispatcher.SendSingleEmail(Subject, singleEmail);
        }

        public async Task<string> FormatEmail(string Name, string Url)
        {
            try
            {
                string body = "";

                var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate\\ResetPassword.html");
                var fileInfo = new FileInfo(tempPath);
                string filename = Path.GetFullPath("EmailTemplate\\AppraisalNotification.html");
                if (fileInfo.Exists)
                {
                    using (StreamReader sr = new StreamReader(fileInfo.FullName))
                    {
                        body = await sr.ReadToEndAsync();
                    }

                    body = body.Replace("{FullName}", Name);
                    body = body.Replace("{GroupName}", "RESOURCE EDGE");
                    body = body.Replace("{Link}", Url);
                    body = body.Replace("{Url}", Url);

                    return body;
                }
                return null;
            }
            catch (Exception ex)
            {
                //log exception here later
                return null;
            }

        }

        public Task<HttpStatusCode> SendMultipleEmail(string subject, string employeeName, EmailDtoForMultiple emailDtos, string message, string title)
        {
            throw new NotImplementedException();
        }

        public Task<string> FormatEmail(string Name, string supervisor, string message, string title, string Url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> FormatEmailAppraisalScore(string Name, string score)
        {
            string[] message = GetEmailMessage(score);
            string Url = "https://resourceedge.herokuapp.com/";
            try
            {
                string body = "";
                string filename = Path.GetFullPath("EmailTemplate\\emailTemplateScore.html");
                using (StreamReader sr = new StreamReader(filename))
                {
                    body = await sr.ReadToEndAsync();
                }

                body = body.Replace("{FirstName}", Name);
                body = body.Replace("{Score}", score);
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
                message[1] = "Excellent";
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

    }



}
