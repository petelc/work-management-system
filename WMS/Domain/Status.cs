using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}