// using Microsoft.AspNetCore.Identity;
// using Domain;

// namespace Persistence
// {
//     public class Seed
//     {
//         public static async Task SeedData(DataContext context,
//             UserManager<AppUser> userManager)
//         {
//             if (!userManager.Users.Any() && !context.Requests.Any())
//             {
//                 var users = new List<AppUser>
//                     {
//                         new AppUser
//                         {
//                             DisplayName = "Peter Carroll",
//                             UserName = "petelc",
//                             Email = "pete@test.com",
//                         },
//                         new AppUser
//                         {
//                             DisplayName = "Robin Carroll",
//                             UserName = "robinec",
//                             Email = "robin@test.com",
//                         },
//                         new AppUser
//                         {
//                             DisplayName = "Logan Karr",
//                             UserName = "loganvk",
//                             Email = "logan@test.com",
//                         }
//                     };

//                 // ! Loop over users list and create using user manager
//                 foreach (var user in users)
//                 {
//                     await userManager.CreateAsync(user, "Pa$$w0rd");
//                 }

//                 var projects = new List<Project>
//                 {
//                     new Project
//                     {
//                         project="New Electronic Forms Application",
//                         description = "A new application to manage all of the forms and buisiness processes",
//                         status = Domain.Enums.Status.Pending,
//                         category = new Category
//                         {
//                             CategoryName="AppDev"
//                         },
//                         requestor = users[0],
//                         ProjectManagers = new List<ProjectManager>
//                         {
//                             new ProjectManager
//                             {
//                                 AppUser = users[1]
//                             }
//                         }
//                     }
//                 };

//                 var changes = new List<Change>
//                 {
//                     new Change
//                     {
//                         change = "Change to DOTS Screen AKJO",
//                         description = "Change Screen AKJO to read yippy dippity",
//                         approvals = Domain.Enums.Approvals.Approved,
//                         priority = Domain.Enums.Priority.Low,
//                         status = Domain.Enums.Status.Pending,
//                     }
//                 };

//                 // ! create requests 
//                 var requests = new List<Request>
//                 {
//                     new Request
//                     {
//                         request = "New Electronic Forms Application",
//                         description = "A new application to manage all of the forms and buisiness processes",
//                         type = Domain.Enums.RequestType.Project,
//                         status = Domain.Enums.Status.Pending,
//                         Requestors = new List<Requestor>
//                         {
//                             new Requestor
//                             {
//                                 AppUser = users[0],
//                                 IsNew = true,
//                             }
//                         },
//                         Project = projects[0],

//                     },

//                     new Request
//                     {
//                         request = "Change to DOTS Screen AKJO",
//                         description = "Change Screen AKJO to read yippy dippity",
//                         type = Domain.Enums.RequestType.Change,
//                         status = Domain.Enums.Status.Pending,
//                         Requestors = new List<Requestor>
//                         {
//                             new Requestor
//                             {
//                                 AppUser = users[1],
//                                 IsNew = true,
//                             }
//                         }
//                     }
//                 };
//                 await context.Changes.AddRangeAsync(changes);
//                 await context.Projects.AddRangeAsync(projects);
//                 await context.Requests.AddRangeAsync(requests);
//                 await context.SaveChangesAsync();
//             }

//         }
//     }
// }