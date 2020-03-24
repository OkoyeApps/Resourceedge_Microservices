using Resourceedge.Email.Api.Model;
using Resourceedge.Email.Api.SGridClient;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resourceedge.Email.Api.Services
{
    public class EmailDispatcher
    {
        private readonly ISGClient client;

        public EmailDispatcher(ISGClient _client)
        {
            client = _client;
        }

        public async Task<HttpStatusCode> SendSingleEmail(string subject, SingleEmailDto emailDto)
        {
            var msg = client.message;
            msg.SetGlobalSubject(subject);
            msg.SetFrom(client.From);

            msg.PlainTextContent = emailDto.PlainTextContent;
            msg.HtmlContent = emailDto.HtmlContent;
            msg.AddTo(emailDto.ReceiverEmailAddress, emailDto.ReceiverFullName);
            msg.AddCc("nwabugwu.akomas@tenece.com", "Nwabugwu Akomas");

            var res = await client.GridClient.SendEmailAsync(msg);

            return res.StatusCode;
        }

        public async Task<HttpStatusCode> SendMultipleEmail(string subject, string plaintextContent, string htmlContent, List<EmailAddress> emails)
        {
            var msg = client.message;
            msg.SetFrom(client.From);
            msg.From = client.From;

            msg.AddTos(emails);
            msg.PlainTextContent = plaintextContent;
            msg.HtmlContent = htmlContent;
            msg.AddCc("nwabugwu.akomas@tenece.com", "Nwabugwu Akomas");

            var res = await client.GridClient.SendEmailAsync(msg);
            return HttpStatusCode.OK;
        }
    }
}
