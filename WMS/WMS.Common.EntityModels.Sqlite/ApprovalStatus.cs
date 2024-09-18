using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Shared;

public partial class ApprovalStatus
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid AprovalStatusId { get; set; }

    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25)]
    public string ApprovalStatusName { get; set; } = null!;
}
