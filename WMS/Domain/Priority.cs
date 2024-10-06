using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Priority
    {
        [Key]
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = null!;
    }
}