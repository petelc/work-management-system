using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("ProjectId", Name = "WorkProject")]
    [Index("ChangeId", Name = "WorkChange")]
    public partial class Work
    {
        public Work()
        {
            WorkItems = new HashSet<WorkItem>();
        }

        [Key]
        public Guid WorkId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [ForeignKey("ProjectId")]
        [InverseProperty("Work")]
        public Project? Project { get; set; }

        [ForeignKey("ChangeId")]
        [InverseProperty("Work")]
        public Change? Change { get; set; }

        [InverseProperty("Work")]
        public ICollection<WorkItem>? WorkItems { get; set; }
    }
}