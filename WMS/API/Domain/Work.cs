using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Domain
{
    public class Work
    {
        public Guid WorkId { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Change Change { get; set; }
        public ICollection<WorkItem> WorkItems { get; set; }
    }
}