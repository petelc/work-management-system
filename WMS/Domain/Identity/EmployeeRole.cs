using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// Represents the roles available to the user.
    /// </summary>
    public class EmployeeRole : IdentityRole<int>
    {
        public virtual ICollection<EmployeeUserRole>? UserRoles { get; set; }
        public virtual ICollection<EmployeeRoleClaim>? RoleClaims { get; set; }
    }
}