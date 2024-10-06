using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApprovalStatus
    {
        [Key]
        public int ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; } = null!;
    }
}