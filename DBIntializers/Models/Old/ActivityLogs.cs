using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class ActivityLogs
    {
        public int Id { get; set; }
        public string Controllername { get; set; }
        public string Actionname { get; set; }
        public string Myip { get; set; }
        public string Parameters { get; set; }
        public string HttpMethod { get; set; }
        public string Requesturl { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
