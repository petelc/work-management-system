using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Shared;

public partial class Priority
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid PriorityId { get; set; }

    [Column(TypeName = "nvarchar (20)")]
    [StringLength(20)]
    public string PriorityName { get; set; } = null!;

    [InverseProperty("Priority")]
    public virtual ICollection<Change> Changes { get; set; } = new List<Change>();

    [InverseProperty("Priority")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
