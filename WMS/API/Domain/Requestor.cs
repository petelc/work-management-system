using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Requestor
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid RequestId { get; set; }
        public Request Requests { get; set; }
        public bool IsNew { get; set; }

    }
}