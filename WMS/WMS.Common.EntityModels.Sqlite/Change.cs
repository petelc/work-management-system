using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("StatusId", Name = "StatusChanges")]
    [Index("ApprovalStatusId", Name = "ApprovalStatusChanges")]
    [Index("EmployeeId", Name = "RequestorChanges")]
    [Index("RequestId", Name = "RequestChanges")]
    [Index("CategoryId", Name = "CategoryChanges")]
    public partial class Change
    {
        public Change()
        {
            ChangeManagers = new HashSet<Employee>();
            Works = new HashSet<Work>();
        }

        [Key]
        public Guid ChangeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (50)")]
        [StringLength(50)]
        public string ChangeName { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [ForeignKey("PriorityId")]
        [InverseProperty("Changes")]
        public Priority? Priority { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("Changes")]
        public Status? Status { get; set; }

        [ForeignKey("ApprovalStatusId")]
        [InverseProperty("Changes")]
        public ApprovalStatus? ApprovalStatus { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Changes")]
        public Employee? requestor { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("Changes")]
        public Request? Requests { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Changes")]
        public Category? Category { get; set; }

        [InverseProperty("Changes")]
        public ICollection<Employee>? ChangeManagers { get; set; }

        [InverseProperty("Changes")]
        public ICollection<Work>? Works { get; set; }
    }
}