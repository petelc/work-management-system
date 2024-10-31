using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// Represents the claim granted to all users within a role. 
    /// </summary>
    public class EmployeeRoleClaim : IdentityRoleClaim<int>
    {
        public virtual EmployeeRole? Role { get; set; }
    }
}