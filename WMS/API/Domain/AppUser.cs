using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Title { get; set; }
    public string Phone { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Requests> Requests { get; set; }
    public ICollection<Requestor> Requestors { get; set; }
    //public ICollection<Project> ProjectManager { get; set; }
    //public ICollection<Change> ChangeManager { get; set; }
    //public ICollection<WorkItem> Assignee { get; set; }
    public ICollection<Assignee> Assignees { get; set; }
    public ICollection<ProjectManager> ProjectManagers { get; set; }
    public ICollection<ChangeManager> ChangeManagers { get; set; }
}
