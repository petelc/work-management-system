using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

[Index("CategoryId", Name = "CategoriesChanges")]
[Index("Requestor", Name = "EmployeesChanges")]
[Index("Request", Name = "RequestsChanges")]
[Index("Work", Name = "WorksChanges")]
public partial class Change
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid ChangeId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? PriorityId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? StatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? CategoryId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Request { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Requestor { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? ApprovalStatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Work { get; set; }

    [Column(TypeName = "NVARCHAR (50)")]
    [StringLength(50)]
    public string ChangeName { get; set; } = null!;

    [Column(TypeName = "NTEXT")]
    public string? Description { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Changes")]
    public virtual Category? Category { get; set; }

    [ForeignKey("PriorityId")]
    [InverseProperty("Changes")]
    public virtual Priority? Priority { get; set; }

    [ForeignKey("Request")]
    [InverseProperty("Changes")]
    public virtual Request? RequestNavigation { get; set; }

    [ForeignKey("Requestor")]
    [InverseProperty("Changes")]
    public virtual Employee? RequestorNavigation { get; set; }

    [ForeignKey("Work")]
    [InverseProperty("Changes")]
    public virtual Work? WorkNavigation { get; set; }

    [InverseProperty("ChangeNavigation")]
    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
