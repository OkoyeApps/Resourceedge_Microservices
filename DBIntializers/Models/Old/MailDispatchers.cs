using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class MailDispatchers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Reciever { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime? TimeToSend { get; set; }
        public int Type { get; set; }
        public string SubGroupName { get; set; }
        public bool Delivered { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }
    }
}
