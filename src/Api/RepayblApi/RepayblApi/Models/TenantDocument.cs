using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RepayblApi.Models
{
    [Index(nameof(TenantId), Name = "fkIdx_117")]
    public partial class TenantDocument : AuditorBase
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public byte[] Payload { get; set; }
        [Required]
        [StringLength(50)]
        public string MimeType { get; set; }
        [Required]
        [StringLength(50)]
        public string FileExtension { get; set; }
        public Guid TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty("TenantDocuments")]
        public virtual Tenant Tenant { get; set; }
    }
}
