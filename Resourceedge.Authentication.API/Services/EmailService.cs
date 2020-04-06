using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.Services;
using Resourceedge.Email.Api.SGridClient;
using System;
using System.Collections.Generic;
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
    }



}
