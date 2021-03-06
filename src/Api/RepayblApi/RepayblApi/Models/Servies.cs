using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable disable

namespace RepayblApi.Models
{
    public partial class Service : AuditorBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(TenantService.Service))]
        public virtual ICollection<TenantService> TenantServices { get; set; }
    }
}
