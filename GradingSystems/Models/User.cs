using System;
using System.Collections.Generic;

namespace GradingSystems.Models
{
    public partial class User
    {
        public User()
        {
            CriteriaToSubmissions = new HashSet<CriteriaToSubmission>();
            UserSubmissions = new HashSet<UserSubmission>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RolesId { get; set; }

        public virtual Role? Roles { get; set; }
        public virtual ICollection<CriteriaToSubmission> CriteriaToSubmissions { get; set; }
        public virtual ICollection<UserSubmission> UserSubmissions { get; set; }
    }
}
