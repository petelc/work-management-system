using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// Represents the user.
    /// </summary>
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

        public Employee()
        {

        }

        public Employee(string userName) : base(userName)
        {

        }


        public ICollection<Request>? Requests { get; set; }
        public ICollection<ChangesToChangeManager>? Changes { get; set; }
        public ICollection<ProjectToProjectManager>? Projects { get; set; }

        // NOTE: Requests submitted to CAB board (ITGG)
        public ICollection<CAB>? CABs { get; set; }

        // NOTE: IDENTITY relationships
        public virtual ICollection<EmployeeClaim>? Claims { get; set; }
        public virtual ICollection<EmployeeLogin>? Logins { get; set; }
        public virtual ICollection<EmployeeToken>? Tokens { get; set; }
        public virtual ICollection<EmployeeUserRole>? UserRoles { get; set; }

    }
}