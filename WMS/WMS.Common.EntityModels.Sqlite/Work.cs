using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Shared;

public partial class Work
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid WorkId { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Project { get; set; }

    [Column(TypeName = "GUID")]
    public Guid? Change { get; set; }

    [Column(TypeName = "NVARCHAR (50)")]
    [StringLength(50)]
    public string? Name { get; set; }

    [ForeignKey("Change")]
    [InverseProperty("Works")]
    public virtual Change? ChangeNavigation { get; set; }

    [InverseProperty("WorkNavigation")]
    public virtual ICollection<Change> Changes { get; set; } = new List<Change>();

    [ForeignKey("Project")]
    [InverseProperty("Works")]
    public virtual Project? ProjectNavigation { get; set; }

    [InverseProperty("WorkNavigation")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
