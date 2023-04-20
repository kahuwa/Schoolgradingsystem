using System;
using System.Collections.Generic;

namespace GradingSystems.Models
{
    public partial class Criterion
    {
        public Criterion()
        {
            CriteriaToSubmissions = new HashSet<CriteriaToSubmission>();
        }

        public int Id { get; set; }
        public string Criteria { get; set; } = null!;

        public virtual ICollection<CriteriaToSubmission> CriteriaToSubmissions { get; set; }
    }
}
