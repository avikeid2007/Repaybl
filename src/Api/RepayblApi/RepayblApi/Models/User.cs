using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RepayblApi.Models
{
    public partial class User : AuditorBase
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Password { get; set; }
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

        [InverseProperty(nameof(Property.User))]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
