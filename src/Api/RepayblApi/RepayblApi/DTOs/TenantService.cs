using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RepayblApi.Constants;

namespace RepayblApi.DTOs
{
    public partial class TenantService
    {

        [Key]
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ServiceId { get; set; }
        public BillingType BillType { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal RatePerUnit { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal FixedAmount { get; set; }
        public Guid RoomId { get; set; }
        public virtual Service Service { get; set; }
        public virtual Room Room { get; set; }
    }
}
