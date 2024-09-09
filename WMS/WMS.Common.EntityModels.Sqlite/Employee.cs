using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("LastName", Name = "LastName")]
    public partial class Employee
    {
        public Employee()
        {
            Requests = new HashSet<Request>();
            Roles = new HashSet<Role>();
        }

        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (20)")]
        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [Required]
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

        [Column(TypeName = "ntext")]
        public string? Notes { get; set; }

        [Column(TypeName = "guid")]
        public Guid? ReportsTo { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Role> Roles { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}