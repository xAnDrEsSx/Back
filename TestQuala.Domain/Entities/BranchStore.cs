using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Domain.Entities
{
    public class BranchStore : BaseDomainModel
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public int Code { get; set; }

        [MaxLength(250)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [MaxLength(250)]
        [Required]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        [Required]
        public string Identification { get; set; } = string.Empty;

        [ForeignKey("TipoDocumento")]
        public Guid CurrencyTypeId { get; set; }

        public virtual CurrencyType CurrencyType { get; set; }
    }
}