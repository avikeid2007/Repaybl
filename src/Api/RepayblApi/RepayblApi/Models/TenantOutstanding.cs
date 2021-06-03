using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RepayblApi.Models
{
    [Index(nameof(TenantId), Name = "fkIdx_144")]
    public partial class TenantOutstanding : AuditorBase
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal? TotalAdvance { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty("TenantOutstandings")]
        public virtual Tenant Tenant { get; set; }
    }
}
