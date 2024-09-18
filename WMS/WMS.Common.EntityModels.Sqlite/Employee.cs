using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

[Index("LastName", Name = "LastName")]
public partial class Employee
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid EmployeeId { get; set; }

    [Column(TypeName = "nvarchar (20)")]
    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar (20)")]
    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar (15)")]
    [StringLength(15)]
    public string? Region { get; set; }

    [Column(TypeName = "nvarchar (30)")]
    [StringLength(30)]
    public string? Institution { get; set; }

    [Column(TypeName = "nvarchar (24)")]
    [StringLength(24)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "nvarchar (10)")]
    [StringLength(10)]
    public string? Extension { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? ReportsTo { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Role { get; set; }

    [Column(TypeName = "ntext")]
    public string? Notes { get; set; }

    [InverseProperty("RequestorNavigation")]
    public virtual ICollection<Change> Changes { get; set; } = new List<Change>();

    [InverseProperty("RequestorNavigation")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [InverseProperty("Employee")]
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    [ForeignKey("Role")]
    [InverseProperty("Employees")]
    public virtual Role? RoleNavigation { get; set; }
}
