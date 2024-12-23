using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class CAB
    {
        [Key]
        public int CABId { get; set; }
        public string RequestName { get; set; } = null!;
        public Request? Request { get; set; }
        public int? RequestRef { get; set; }
        public int  Votes { get; set; }
        public Employee? Member { get; set; }
        public int? MemberRef { get; set; }
        public int? ChangeRef { get; set; }
        public Change? Change { get; set; }
        public int? ProjectRef { get; set; }
        public Project? Project { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}