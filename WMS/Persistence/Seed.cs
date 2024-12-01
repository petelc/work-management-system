using Domain;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(WMSContext context, UserManager<Employee> userManager)
        {
            if (!userManager.Users.Any() && !context.Requests.Any())
            {
                var board = new List<Employee>
                {
                    new Employee
                    {
                        DisplayName = "Salvador Hodges",
                        LastName = "Hodges",
                        FirstName = "Salvador",
                        Region = "",
                        Institution = "",
                        Extension = "23646",
                        Notes = "",
                        UserName = "sal",
                        Email = "salvador@example.com",
                        PhoneNumber = "555-555-5555"
                    },
                    new Employee
                    {
                        DisplayName = "Sandy Patrick",
                        LastName = "Patrick",
                        FirstName = "Sandy",
                        Region = "",
                        Institution = "",
                        Extension = "23647",
                        Notes = "",
                        UserName = "sandy",
                        Email = "sandy@example.com",
                        PhoneNumber = "555-555-5556"
                    }
                };

                foreach (var member in board)
                {
                    await userManager.CreateAsync(member, "Pa$$w0rd");
                    await userManager.AddToRolesAsync(member, new[] { "Board Member", "Staff" });
                }

                var change = new List<Employee>
                {
                    new Employee
                    {
                        DisplayName = "Stella Holt",
                        LastName = "Holt",
                        FirstName = "Stella",
                        Region = "",
                        Institution = "",
                        Extension = "23647",
                        Notes = "",
                        UserName = "stella",
                        Email = "stella@example.com",
                        PhoneNumber = "555-555-5557"
                    },
                    new Employee
                    {
                        DisplayName = "Beatriz Edwards",
                        LastName = "Edwards",
                        FirstName = "Beatriz",
                        Region = "",
                        Institution = "",
                        Extension = "23648",
                        Notes = "",
                        UserName = "beatiz",
                        Email = "beatriz@example.com",
                        PhoneNumber = "555-555-5558"
                    }
                };

                foreach (var member in change)
                {
                    await userManager.CreateAsync(member, "Pa$$w0rd");
                    await userManager.AddToRolesAsync(member, new[] { "Change Manager", "Staff" });
                }

                var project = new List<Employee>
                {
                    new Employee
                    {
                        DisplayName = "Christian Reeves",
                        LastName = "Reeves",
                        FirstName = "Christian",
                        Region = "",
                        Institution = "",
                        Extension = "23649",
                        Notes = "",
                        UserName = "christian",
                        Email = "christian@example.com",
                        PhoneNumber = "555-555-5559"
                    },
                    new Employee
                    {
                        DisplayName = "Sang Holmes",
                        LastName = "Holmes",
                        FirstName = "Sang",
                        Region = "",
                        Institution = "",
                        Extension = "23650",
                        Notes = "",
                        UserName = "sang",
                        Email = "sang@example.com",
                        PhoneNumber = "555-555-5560"
                    }
                };

                foreach (var member in project)
                {
                    await userManager.CreateAsync(member, "Pa$$w0rd");
                    await userManager.AddToRolesAsync(member, new[] { "Project Manager", "Staff" });
                }

                var dev = new Employee
                {
                    DisplayName = "Glenn Russell",
                    LastName = "Russell",
                    FirstName = "Glenn",
                    Region = "",
                    Institution = "",
                    Extension = "23651",
                    Notes = "",
                    UserName = "glenn",
                    Email = "glenn@example.com",
                    PhoneNumber = "555-555-5561"
                };

                await userManager.CreateAsync(dev, "Pa$$w0rd");
                await userManager.AddToRoleAsync(dev, "Developer");

                var tech = new Employee
                {
                    DisplayName = "Yvette Harrison",
                    LastName = "Harrison",
                    FirstName = "Yvette",
                    Region = "",
                    Institution = "",
                    Extension = "23652",
                    Notes = "",
                    UserName = "yvette",
                    Email = "yvette@example.com",
                    PhoneNumber = "555-555-5562"
                };

                await userManager.CreateAsync(tech, "Pa$$w0rd");
                await userManager.AddToRoleAsync(tech, "Tech");


                // ! Requests
                var requests = new List<Request>
                {
                    new Request
                    {
                        RequestTitle = "Request 1",
                        Description = "Request to get something changed",
                        IsNew = true,
                        Requestor = new Employee
                            {
                                EmployeeId = board[0].EmployeeId,
                                DisplayName = board[0].DisplayName,
                                LastName = board[0].LastName,
                                FirstName = board[0].FirstName,
                                Region = board[0].Region,
                                Institution = board[0].Institution,
                                Extension = board[0].Extension,
                                Notes = board[0].Notes,
                                UserName = board[0].UserName,
                                Email = board[0].Email,
                                PhoneNumber = board[0].PhoneNumber
                            }
                    },
                    new Request
                    {
                        RequestTitle = "Request 2",
                        Description = "Request to get new project",
                        IsNew = true,
                        Requestor = new Employee
                        {
                            EmployeeId = board[2].EmployeeId,
                            DisplayName = board[2].DisplayName,
                            LastName = board[2].LastName,
                            FirstName = board[2].FirstName,
                            Region = board[2].Region,
                            Institution = board[2].Institution,
                            Extension = board[2].Extension,
                            Notes = board[2].Notes,
                            UserName = board[2].UserName,
                            Email = board[2].Email,
                            PhoneNumber = board[2].PhoneNumber
                        }
                    }
                };

                // ! Change
                var changes = new List<Change>
                {
                    new Change
                    {
                        ChangeName = "Change 1",
                        Description = "Request for a change to something",
                        ChangeManagers = new List<ChangesToChangeManager>
                        {
                            new ChangesToChangeManager
                            {
                                Employee = change[0],
                                IsNew = true,
                            }
                        }
                    },
                    new Change
                    {
                        ChangeName = "Change 2",
                        Description = "Request for a change to something else",
                        ChangeManagers = new List<ChangesToChangeManager>
                        {
                            new ChangesToChangeManager
                            {
                                Employee = change[1],
                                IsNew = true,
                            }
                        }
                    }
                };

                var projects = new List<Project>
                {
                    new Project
                    {
                        ProjectName = "Project 1",
                        Description = "A new Project",
                        ProjectManagers = new List<ProjectToProjectManager>
                        {
                            new ProjectToProjectManager
                            {
                                Employee = project[0],
                                IsNew = true,
                            }
                        }
                    },
                    new Project
                    {
                        ProjectName = "Project 2",
                        Description = "Another new Project",
                        ProjectManagers = new List<ProjectToProjectManager>
                        {
                            new ProjectToProjectManager
                            {
                                Employee = project[1],
                                IsNew = true,
                            }
                        }
                    }
                };

            }
            await context.SaveChangesAsync();
        }
    }
}