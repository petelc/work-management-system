using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("TypeId", Name = "RequestTypeRequest")]
    [Index("StatusId", Name = "StatusRequest")]
    [Index("ApprovalStatusId", Name = "ApprovalStatusRequest")]
    public partial class Request
    {
        public Request()
        {
            Requestors = new HashSet<Employee>();
        }
        [Key]
        public Guid RequestId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (40)")]
        [StringLength(40)]
        public string RequestTitle { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Column(TypeName = "bit")]
        public bool IsNew { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Requests")]
        public RequestType? Type { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("Requests")]
        public Status? Status { get; set; }

        [ForeignKey("ApprovalStatusId")]
        [InverseProperty("Requests")]
        public ApprovalStatus? ApprovalStatus { get; set; }

        [InverseProperty("Requests")]
        public ICollection<Employee> Requestors { get; set; }
    }
}