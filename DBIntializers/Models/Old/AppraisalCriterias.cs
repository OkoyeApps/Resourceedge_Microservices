using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AppraisalCriterias
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string CriteriaFive { get; set; }
        public string CriteriaFour { get; set; }
        public string CriteriaThree { get; set; }
        public string CriteriaTwo { get; set; }
        public string CriteriaOne { get; set; }

        public virtual Questions Question { get; set; }
    }
}
