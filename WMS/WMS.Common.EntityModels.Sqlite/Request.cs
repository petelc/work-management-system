using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

[Index("EmployeeId", Name = "EmployeeId")]
[Index("EmployeeId", Name = "EmployeesRequests")]
public partial class Request
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid RequestId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? RequestTypeId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? StatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? ApprovalStatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? EmployeeId { get; set; }

    [Column(TypeName = "NVARCHAR (40)")]
    public string RequestTitle { get; set; } = null!;

    [Column(TypeName = "NTEXT")]
    public string? Description { get; set; }

    [Column(TypeName = "BIT")]
    public bool? IsNew { get; set; }

    [InverseProperty("RequestNavigation")]
    public virtual ICollection<Change> Changes { get; set; } = new List<Change>();

    [ForeignKey("EmployeeId")]
    [InverseProperty("Requests")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("RequestNavigation")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [ForeignKey("RequestTypeId")]
    [InverseProperty("Requests")]
    public virtual RequestType? RequestType { get; set; }

    [ForeignKey("ApprovalStatusId")]
    [InverseProperty("Requests")]
    public virtual ApprovalStatus? ApprovalStatus { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Requests")]
    public virtual Statuses? Status { get; set; }
}
