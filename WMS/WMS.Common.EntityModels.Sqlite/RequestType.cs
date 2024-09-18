using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Shared;

public partial class RequestType
{
    [Key]
    [Column(TypeName = "GUID")]
    public Guid RequestTypeId { get; set; }

    [Column(TypeName = "NVARCHAR (25)")]
    [StringLength(25)]
    public string RequestTypeName { get; set; } = null!;

    [InverseProperty("RequestType")]
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
