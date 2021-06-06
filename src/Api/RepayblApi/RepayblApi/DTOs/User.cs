using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RepayblApi.Models;

namespace RepayblApi.DTOs
{
    public partial class User
    {

        [Key]
        public Guid Id { get; set; }

        public bool IsAuth { get; set; }
        public bool IsPropertyOwner { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        public int? Zip { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
