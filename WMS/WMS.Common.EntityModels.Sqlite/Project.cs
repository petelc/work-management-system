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
    [Index("PriorityId", Name = "PriorityProjects")]
    public partial class Project
    {
        public Project()
        {
            Works = new HashSet<Work>();
            ProjectManagers = new HashSet<Employee>();
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

        [Column(TypeName = "Guid")]
        public Guid? RequestId { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("Projects")]
        public Request? Request { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Projects")]
        public Category? Category { get; set; }

        [ForeignKey("PriorityId")]
        [InverseProperty("Projects")]
        public Priority? Priority { get; set; }

        [InverseProperty("Projects")]
        public ICollection<Employee>? ProjectManagers { get; set; }

        [InverseProperty("Projects")]
        public virtual ICollection<Work> Works { get; set; }
    }
}