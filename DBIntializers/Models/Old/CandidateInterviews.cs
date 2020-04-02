using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class CandidateInterviews
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidates Candidate { get; set; }
        public virtual Interviews Interview { get; set; }
    }
}
