using System;
using System.Collections.Generic;

namespace GradingSystems.Models
{
    public partial class UserSubmission
    {
        public UserSubmission()
        {
            CriteriaToSubmissions = new HashSet<CriteriaToSubmission>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Github { get; set; } = null!;

        public virtual User? User { get; set; }
        public virtual ICollection<CriteriaToSubmission> CriteriaToSubmissions { get; set; }
    }
}
