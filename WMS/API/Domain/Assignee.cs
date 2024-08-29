using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Assignee
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid WorkItemId { get; set; }
        public WorkItem WorkItems { get; set; }
    }
}