using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Common.EntityModels.Sqlite
{
    /// <summary>
    /// Provides a way to define what role an employee plays within the organization
    /// Roles are: Staff, Project Manager, Change Manager, Supervisor, Developer, Technician 
    /// </summary>
    public partial class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        [StringLength(25)]
        public string RoleName { get; set; } = null!;

        // TODO - Define relationships with Employee Class
    }
}