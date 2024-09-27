using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeeData(WMSContext context, UserManager<Employee> userManager)
        {
            await context.SaveChangesAsync();
        }
    }
}