using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Identity
{
    /// <summary>
    /// Associates a login with a user. 
    /// </summary>

    public class EmployeeLogin : IdentityUserLogin<int>
    {

        public virtual Employee? User { get; set; }
    }
}