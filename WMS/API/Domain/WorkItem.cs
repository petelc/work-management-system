using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class WorkItem
    {
        // NOTE: Need to add the Connected Card property once we figure out what that is.
        public Guid WorkItemId { get; set; }
        public string CardNum { get; set; }
        public string Title { get; set; }
        public Icon Icon { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AppUser Assignee { get; set; }
        public Work Work { get; set; }

        public ICollection<Assignee> Assignees { get; set; } = new List<Assignee>();
    }
}