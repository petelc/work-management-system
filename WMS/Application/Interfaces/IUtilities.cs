using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities;
using Domain.Identity;

namespace Application.Interfaces
{
    public interface IUtilities
    {
        EmployeeDto CreateUserObject(Employee user);
    }
}