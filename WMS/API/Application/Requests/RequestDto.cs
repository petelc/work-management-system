using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Application.Profiles;
using Domain;

namespace Application.Requests
{
    public class RequestDto
    {
        public Guid RequestId { get; set; }
        public string request { get; set; }
        public string description { get; set; }
        public RequestType type { get; set; }
        public Status status { get; set; }
        public Approvals approvals { get; set; }
        public Project Project { get; set; }
        public Change Change { get; set; }
        public string RequestorUsername { get; set; }
        public ICollection<RequestorDto> Requestors { get; set; }
    }
}