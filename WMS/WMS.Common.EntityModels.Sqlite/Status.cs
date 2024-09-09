using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Keyless]
    public partial class Status
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        public string StatusId { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar")]
        public string StatusName { get; set; } = null!;
    }
}