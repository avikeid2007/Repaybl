using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepayblApi.Models
{
    [Index(nameof(UserId), Name = "fkIdx_151")]
    public partial class Property : AuditorBase
    {
        public Property()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        public string Zip { get; set; }
        public int FloorCount { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Properties")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Room.Property))]
        public virtual ICollection<Room> Rooms { get; set; }

        [InverseProperty(nameof(PropertyMedia.Property))]
        public virtual ICollection<PropertyMedia> PropertyMedias { get; set; }
    }
}
