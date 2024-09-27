using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkToWorkItem
    {
        public string WorkId { get; set; }
        public Work Work { get; set; }
        public Guid WorkItemId { get; set; }
        public WorkItem WorkItem { get; set; }
        public bool IsApproved { get; set; }
        public bool IsComplete { get; set; }
    }
}