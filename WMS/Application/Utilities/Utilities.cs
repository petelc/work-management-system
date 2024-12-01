using Application.Interfaces;
using Domain.Identity;


namespace Application.Utilities
{
    public class Utilities : IUtilities
    {
        public EmployeeDto CreateUserObject(Employee user)
        {
            return new EmployeeDto
            {
                Id = user.Id,
                EmployeeId = user.EmployeeId,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Username = user.UserName,
                LastName = user.LastName,
                FirstName = user.FirstName,
            };
        }
    }
}