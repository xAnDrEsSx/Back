namespace TestQuala.Domain.Entities.Common
{
    public record class BaseDomainModel
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
    }
}