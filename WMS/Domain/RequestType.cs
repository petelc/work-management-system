using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class RequestType
    {
        [Key]
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; } = null!;
    }
}