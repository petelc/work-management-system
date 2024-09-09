using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Common.EntityModels.Sqlite
{
    public partial class Category
    {
        public Category()
        {
            Projects = new HashSet<Project>();
            Changes = new HashSet<Change>();
        }

        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (15)")]
        [StringLength(15)]
        public string CategoryName { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Project> Projects { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Change> Changes { get; set; }
    }
}