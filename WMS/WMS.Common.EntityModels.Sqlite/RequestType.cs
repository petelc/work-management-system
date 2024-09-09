using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    /**
    * TODO - Implement this class similiar to the Territory Class
    */
    [Keyless]
    public partial class RequestType
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        public string RequestTypeId { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar")]
        public string RequestTypeName { get; set; } = null!;

        [Column(TypeName = "int")]
        public int TypeId { get; set; }
    }
}