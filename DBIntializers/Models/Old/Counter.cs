using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Counter
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public short Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
