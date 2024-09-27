using Microsoft.AspNetCore.Identity;

namespace Domain
{

    public partial class Employee : IdentityUser
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Region { get; set; }
        public string Institution { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public Guid ReportsTo { get; set; }
        public ICollection<RequestToRequestors> Requests { get; set; }
        public ICollection<ChangesToChangeManager> Changes { get; set; }
        public ICollection<ProjectToProjectManager> Projects { get; set; }

    }
}