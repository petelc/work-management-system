using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Common.EntityModels.Sqlite
{
    public class ApprovalStatus
    {
        [Key]
        public Guid ApprovalStatusId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        [StringLength(25)]
        public string ApprovalStatusName { get; set; } = null!;
    }
}