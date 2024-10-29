using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// Represents a claim a user posesses. 
    /// </summary>
    public class EmployeeClaim : IdentityUserClaim<int>
    {
        // [Key]
        // public string Id { get; set; } = null!;
        public virtual Employee? User { get; set; }
    }
}