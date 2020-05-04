using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SystemConfigs
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int Sequence { get; set; }
        public bool AutoGenerate { get; set; }
        public DateTime Date { get; set; }
        public bool FirstGenerated { get; set; }
        public bool UseYear { get; set; }
        public int? ZeroFormat { get; set; }
        public int? YearFormat { get; set; }
    }
}
