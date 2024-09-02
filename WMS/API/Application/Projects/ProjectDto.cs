using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string project { get; set; }
        public string description { get; set; }
    }
}