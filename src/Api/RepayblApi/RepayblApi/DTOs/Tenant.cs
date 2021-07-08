using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RepayblApi.DTOs
{
    public partial class Tenant
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
        public int FamilyMamberCount { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DOJ { get; set; }
        public Guid UserId { get; set; }
        public string IDType { get; set; }
        public string IDCardNumber { get; set; }
        public Guid[] RoomIds { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<TenantService> TenantServices { get; set; }
        public ICollection<FamilyDetail> FamilyDetails { get; set; }
    }
}
