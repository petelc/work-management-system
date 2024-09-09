using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Keyless]
    public partial class Priority
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        public string PriorityId { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar")]
        public string PriorityName { get; set; } = null!;
    }
}