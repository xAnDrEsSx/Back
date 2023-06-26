using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Domain.Entities
{
    public class CurrencyType : BaseDomainModel
    {
        /// <summary>
        /// Id Currency
        /// </summary>
        [Key]
        [Comment("Unique ID")]
        public Guid Id { get; set; } = new Guid();

        [Comment("Currency Description")]
        [Required]
        [MaxLength(50)]
        public string CurrencyName { get; set; } = string.Empty;
    }
}
