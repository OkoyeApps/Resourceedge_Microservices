using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.Services;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.Services
{
    public class EmailService
    {
        private readonly ISGClient client;
        EmailDispatcher dispatcher;
        public EmailService(ISGClient _client)
        {
            client = _client;
            dispatcher = new EmailDispatcher(client);
        }

        public async Task<HttpStatusCode> SendToSingleEmployee(string Subject, SingleEmailDto singleEmail)
        {
            return await dispatcher.SendSingleEmail(Subject, singleEmail);
        }

        public async Task<string> FormatEmail(string Name, string Url)
        {
            string body = "";
            var AppDomains = AppDomain.CurrentDomain.FriendlyName;
            string filename = Path.GetFullPath("Utils\\EmailTemplate\\ResetPassword.html");
            using (StreamReader sr = new StreamReader(filename))
            {
                body = await sr.ReadToEndAsync();
            }

            body = body.Replace("{FullName}", Name);
            body = body.Replace("{GroupName}", "RESOURCE EDGE");
            body = body.Replace("{Link}", Url);
            body = body.Replace("{Url}", Url);

            return body;
        }
    }



}
