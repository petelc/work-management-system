using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectToProjectManager
    {
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public bool IsNew { get; set; }
    }
}