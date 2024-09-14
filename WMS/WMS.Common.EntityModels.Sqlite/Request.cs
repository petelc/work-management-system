using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("RequestTypeId", Name = "RequestType")]
    [Index("RequestTypeId", Name = "RequestTypeId")]
    [Index("StatusId", Name = "StatusRequest")]
    [Index("StatusId", Name = "StatusId")]
    [Index("ApprovalStatusId", Name = "ApprovalStatusRequest")]
    [Index("ApprovalStatusId", Name = "ApprovalStatusId")]
    public partial class Request
    {
        public Request()
        {
            Requestors = new HashSet<Employee>();
        }

        [Key]
        public Guid RequestId { get; set; }

        [Column(TypeName = "Guid")]
        public Guid? RequestTypeId { get; set; }

        [Column(TypeName = "Guid")]
        public Guid? StatusId { get; set; }

        [Column(TypeName = "Guid")]
        public Guid? ApprovalStatusId { get; set; }

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

        [ForeignKey("RequestTypeId")]
        [InverseProperty("Requests")]
        public virtual RequestType? Type { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("Requests")]
        public virtual Status? Status { get; set; }

        [ForeignKey("ApprovalStatusId")]
        [InverseProperty("Requests")]
        public virtual ApprovalStatus? ApprovalStatus { get; set; }

        [InverseProperty("Requests")]
        public virtual ICollection<Employee> Requestors { get; set; }
    }
}