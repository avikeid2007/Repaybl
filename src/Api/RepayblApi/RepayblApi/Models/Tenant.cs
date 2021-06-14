using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RepayblApi.Models
{
    public partial class Tenant : AuditorBase
    {
        public Tenant()
        {
            FamilyDetails = new HashSet<FamilyDetail>();
            RentTransactions = new HashSet<RentTransaction>();
            Rooms = new HashSet<Room>();
            TenantDocuments = new HashSet<TenantDocument>();
            TenantOutstandings = new HashSet<TenantOutstanding>();
        }

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
        public DateTime? DOL { get; set; }
        public string IDType { get; set; }
        public string IDCardNumber { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Tenants")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(FamilyDetail.Tenant))]
        public virtual ICollection<FamilyDetail> FamilyDetails { get; set; }
        [InverseProperty(nameof(RentTransaction.PaidByNavigation))]
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        [InverseProperty(nameof(Room.CurrentTenant))]
        public virtual ICollection<Room> Rooms { get; set; }
        [InverseProperty(nameof(TenantDocument.Tenant))]
        public virtual ICollection<TenantDocument> TenantDocuments { get; set; }
        [InverseProperty(nameof(TenantOutstanding.Tenant))]
        public virtual ICollection<TenantOutstanding> TenantOutstandings { get; set; }
        [InverseProperty(nameof(TenantService.Tenant))]
        public virtual ICollection<TenantService> TenantServices { get; set; }
    }
}
