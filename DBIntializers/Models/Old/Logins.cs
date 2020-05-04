using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Logins
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogOutTime { get; set; }
        public bool IsLogIn { get; set; }
        public bool IsLogOut { get; set; }
    }
}
