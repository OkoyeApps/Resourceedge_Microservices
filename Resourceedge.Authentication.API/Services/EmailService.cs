﻿using Resourceedge.Email.Api.Interfaces;
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
    }



}
