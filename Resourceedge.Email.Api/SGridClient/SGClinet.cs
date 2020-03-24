using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Email.Api.SGridClient
{
    public class SGClient : ISGClient
    {
        public SendGridClient GridClient { get; set; }
        public EmailAddress From { get; set; } = new EmailAddress("ResourceedgeFeedback@tenece.com","ResourceEdge");
        public SendGridMessage message { get; set; } = new SendGridMessage();

        public static SGClient Create(string apiKey)
        {

            SGClient gridClient = new SGClient();
            gridClient.GridClient = new SendGridClient(apiKey);
            return gridClient;
        }

    }
}
