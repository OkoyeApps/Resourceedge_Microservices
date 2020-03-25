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

            var res = await client.GridClient.SendEmailAsync(msg);

            return res.StatusCode;
        }

        public async Task<HttpStatusCode> SendSingleMailToMultipleEmail(string subject, string plaintextContent, string htmlContent, List<EmailAddress> emails)
        {

            emails.Add(new EmailAddress("kingdav.ndcdavison@gamil.com", "Nwabugwu Akomas"));
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(client.From, emails, subject, plaintextContent, htmlContent);
            var res = await client.GridClient.SendEmailAsync(msg);

            return res.StatusCode;
        }

        public async Task<HttpStatusCode> SendMultipleMailToMultipleEmail(List<string> subject, string plaintextContent, string htmlContent, List<EmailAddress> emails, List<Dictionary<string,string>> substitute )
        {
            var msg = MailHelper.CreateMultipleEmailsToMultipleRecipients(client.From, emails, subject, plaintextContent, htmlContent, substitute);
            var res = await client.GridClient.SendEmailAsync(msg);

            return res.StatusCode;
        }
    }
}
