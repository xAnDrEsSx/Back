using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Domain.Entities
{
    public record class CurrencyType : BaseDomainModel
    {
        #region params
        
        /// <summary>
        /// Id Currency
        /// </summary>
        [Comment("Unique ID")]
        public Guid Id { get; set; } = new Guid();

        [Comment("Currency Description")]
        [MaxLength(50)]
        public string CurrencyName { get; set; } = string.Empty;

        #endregion
    }
}
