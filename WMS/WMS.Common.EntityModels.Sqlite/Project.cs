using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

[Index("CategoryId", Name = "CategoriesProjects")]
[Index("CategoryId", Name = "CategoryId")]
[Index("Requestor", Name = "EmployeesProjects")]
[Index("Request", Name = "RequestsProjects")]
[Index("Work", Name = "WorksProjects")]
public partial class Project
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid ProjectId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? StatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? ApprovalStatusId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Requestor { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Request { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? CategoryId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? PriorityId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Work { get; set; }

    [Column(TypeName = "NVARCHAR (50)")]
    [StringLength(50)]
    public string ProjectName { get; set; } = null!;

    [Column(TypeName = "NTEXT")]
    public string? Description { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Projects")]
    public Statuses? Status { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Projects")]
    public virtual Category? Category { get; set; }

    [ForeignKey("PriorityId")]
    [InverseProperty("Projects")]
    public virtual Priority? Priority { get; set; }

    [ForeignKey("Request")]
    [InverseProperty("Projects")]
    public virtual Request? RequestNavigation { get; set; }

    [ForeignKey("Requestor")]
    [InverseProperty("Projects")]
    public virtual Employee? RequestorNavigation { get; set; }

    [ForeignKey("Work")]
    [InverseProperty("Projects")]
    public virtual Work? WorkNavigation { get; set; }

    [InverseProperty("ProjectNavigation")]
    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
