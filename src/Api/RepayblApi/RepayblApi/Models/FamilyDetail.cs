using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepayblApi.Models
{
    [Index(nameof(TenantId), Name = "fkIdx_79")]
    public partial class FamilyDetail : AuditorBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        public string Zip { get; set; }
        public Guid TenantId { get; set; }
        [StringLength(50)]
        public string Relationship { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty("FamilyDetails")]
        public virtual Tenant Tenant { get; set; }
    }
}
