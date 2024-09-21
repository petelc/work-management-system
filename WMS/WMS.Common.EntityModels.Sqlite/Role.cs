using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

//[Index("RoleId", Name = "EmployeeRole")]
public partial class Role
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid RoleId { get; set; }

    [Column(TypeName = "NVARCHAR (25)")]
    [StringLength(25)]
    public string RoleName { get; set; } = null!;

    // [InverseProperty("Role")]
    // public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
