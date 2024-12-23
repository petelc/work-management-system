#nullable enable
using Domain;
using Domain.Identity;

namespace Application.CABs
{
    public class CABDto
    {
        public int CABId { get; set; }
        public string RequestName { get; set; } = null!;
        public int  Votes { get; set; }
        public Request? Request { get; set; }
        public Employee? Member { get; set; }
        public Change? Change { get; set; }
        public Project? Project { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}