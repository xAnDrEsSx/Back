using System.ComponentModel.DataAnnotations;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Domain.Entities
{
    public record class BranchStore : BaseDomainModel
    {
        public Guid Id { get; set; } = new Guid();
        public int Code { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Identification { get; set; } = string.Empty;
    }
}