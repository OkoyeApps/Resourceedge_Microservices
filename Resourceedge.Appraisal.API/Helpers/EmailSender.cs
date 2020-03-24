using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.Services;
using Resourceedge.Email.Api.SGridClient;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
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


            return await dispatcher.SendMultipleEmail(subject, textContent, htmlContent, emails);

        }

    }
}
