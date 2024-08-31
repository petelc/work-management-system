using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ChangeManager
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ChangeId { get; set; }
        public Change Changes { get; set; }
    }
}