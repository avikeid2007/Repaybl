using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RepayblApi.Constants;

#nullable disable

namespace RepayblApi.Models
{
    public partial class TenantService : AuditorBase
    {

        [Key]
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid RoomId { get; set; }
        public BillingType BillType { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal RatePerUnit { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal FixedAmount { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty("TenantServices")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("TenantServices")]
        public virtual Service Service { get; set; }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty("TenantServices")]
        public virtual Room Room { get; set; }

    }
}
