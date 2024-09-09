using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Common.EntityModels.Sqlite
{
    [Index("StatusId", Name = "StatusProjects")]
    [Index("ApprovalStatusId", Name = "ApprovalStatusProjects")]
    [Index("EmployeeId", Name = "RequestorProjects")]
    [Index("RequestId", Name = "RequestProjects")]
    [Index("CategoryId", Name = "CategoryProjects")]
    public partial class Project
    {
        public Project()
        {
            Works = new HashSet<Work>();
        }

        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (50)")]
        [StringLength(50)]
        public string ProjectName { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [ForeignKey("StatusId")]
        [InverseProperty("Projects")]
        public Status? Status { get; set; }

        [ForeignKey("ApprovalStatusId")]
        [InverseProperty("Projects")]
        public ApprovalStatus? ApprovalStatus { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Projects")]
        public Employee? Requestor { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("Projects")]
        public Request? Request { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Projects")]
        public Category? Category { get; set; }

        // TODO - Need to define an Employee that has the role of Project Manager

        [InverseProperty("Projects")]
        public virtual ICollection<Work>? Works { get; set; }
    }
}