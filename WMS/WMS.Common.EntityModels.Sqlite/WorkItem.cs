using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("WorkId", Name = "WorkId")]
    [Index("WorkId", Name = "Work_WorkItem")]
    [Index("EmployeeId", Name = "AssigneeWorkItem")]
    [Index("PriorityId", Name = "PriorityWorkItem")]
    public partial class WorkItem
    {
        [Key]
        public Guid CardId { get; set; }

        [Key]
        public Guid WorkId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (10)")]
        [StringLength(10)]
        public string CardIDNum { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar (25)")]
        [StringLength(25)]
        public string Header { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar (25)")]
        [StringLength(25)]
        public string Title { get; set; } = null!;

        [Column(TypeName = "nvarchar (50)")]
        [StringLength(50)]
        public string? Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("WorkItem")]
        public Employee? Assignee { get; set; }

        [ForeignKey("PriorityId")]
        [InverseProperty("WorkItem")]
        public Priority? Priority { get; set; }

        [ForeignKey("WorkId")]
        [InverseProperty("WorkItem")]
        public virtual Work Work { get; set; } = null!;

        // TODO - Connected Card, Icon, and Tag
    }
}