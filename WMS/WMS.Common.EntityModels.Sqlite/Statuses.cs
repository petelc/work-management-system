using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Shared
{
    public class Statuses
    {
        [Key]
        [Column(TypeName = "GUID")]
        public Guid StatusId { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        [StringLength(25)]
        public string StatusName { get; set; } = null!;
    }
}