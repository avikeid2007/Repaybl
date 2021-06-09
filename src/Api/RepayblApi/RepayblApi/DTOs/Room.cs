using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RepayblApi.Models;

namespace RepayblApi.DTOs
{
    public partial class Room : AuditorBase
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        public int? RoomFloorNo { get; set; }
        public Guid PropertyId { get; set; }
        public Guid? CurrentTenantId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastBillPaidDate { get; set; }
        public Guid? LastPaidBillId { get; set; }

    }
}
