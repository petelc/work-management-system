using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Keyless]
    public partial class RequestTypeRequest
    {
        [Column(TypeName = "Guid")]
        public Guid RequestId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string RequestTypeId { get; set; } = null!;
    }
}