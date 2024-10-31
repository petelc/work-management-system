using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    /// <summary>
    /// represents an authentication token for a user. 
    /// </summary>
    public class EmployeeToken : IdentityUserToken<int>
    {
        public virtual Employee? User { get; set; }
    }
}