using System;
using System.Collections.Generic;

namespace GradingSystems.Models
{
    public partial class CriteriaToSubmission
    {
        public int SubmissionId { get; set; }
        public int CriteriaId { get; set; }
        public int TeacherId { get; set; }
        public int? Grade { get; set; }
        public string? CommentTeacher { get; set; }

        public virtual Criterion Criteria { get; set; } = null!;
        public virtual UserSubmission Submission { get; set; } = null!;
        public virtual User Teacher { get; set; } = null!;
    }
}
