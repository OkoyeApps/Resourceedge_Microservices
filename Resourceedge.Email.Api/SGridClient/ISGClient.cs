using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Email.Api.SGridClient
{
    public interface ISGClient
    {
        public SendGridClient GridClient { get; set; }

        public EmailAddress From { get; set; }
        public SendGridMessage message { get; set; }
    }
}
