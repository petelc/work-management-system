using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// a join entity that associates users and roles. 
    /// </summary>
    public class EmployeeUserRole : IdentityUserRole<int>
    {

        public virtual Employee? User { get; set; }
        public virtual EmployeeRole? Role { get; set; }
    }
}