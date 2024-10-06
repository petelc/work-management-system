using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Employee : IdentityUser<int>
    {
        public int EmployeeId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Region { get; set; }
        public string? Institution { get; set; }
        public string? Extension { get; set; }
        public string? Notes { get; set; }
        public int? ReportsTo { get; set; }
        public ICollection<RequestToRequestors>? Requests { get; set; }
        public ICollection<ChangesToChangeManager>? Changes { get; set; }
        public ICollection<ProjectToProjectManager>? Projects { get; set; }

    }
}