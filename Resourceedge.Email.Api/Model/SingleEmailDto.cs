using System.Collections.Generic;

namespace Resourceedge.Email.Api.Model
{
    public class SingleEmailDto
    {
        public string ReceiverEmailAddress { get; set; }
        public string ReceiverFullName { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }

    public class EmailDtoForMultiple
    {
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
        public ICollection<EmailObject> EmailObjects { get; set; }
    }

    public class EmailObject
    {
        public string ReceiverEmailAddress { get; set; }
        public string ReceiverFullName { get; set; }
    }
}
