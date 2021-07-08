using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepayblApi.Models
{
    [Index(nameof(LastPaidBillId), Name = "fkIdx_134")]
    [Index(nameof(PropertyId), Name = "fkIdx_37")]
    [Index(nameof(CurrentTenantId), Name = "fkIdx_52")]
    public partial class Room : AuditorBase
    {
        public Room()
        {
            RentTransactions = new HashSet<RentTransaction>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        public string RoomFloorNo { get; set; }
        public Guid PropertyId { get; set; }
        public Guid? CurrentTenantId { get; set; }
        //[Column(TypeName = "numeric(8, 2)")]
        //public decimal MonthlyRent { get; set; }
        //[Column(TypeName = "numeric(2, 2)")]
        //public decimal ElectRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastBillPaidDate { get; set; }
        public Guid? LastPaidBillId { get; set; }

        [ForeignKey(nameof(CurrentTenantId))]
        [InverseProperty(nameof(Tenant.Rooms))]
        public virtual Tenant CurrentTenant { get; set; }
        [ForeignKey(nameof(PropertyId))]
        [InverseProperty("Rooms")]
        public virtual Property Property { get; set; }
        [InverseProperty(nameof(RentTransaction.Room))]
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        [InverseProperty(nameof(PropertyMedia.Room))]
        public virtual ICollection<PropertyMedia> PropertyMedias { get; set; }
    }
}
