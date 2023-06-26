namespace TestQuala.Domain.Entities.Common
{
    public class BaseDomainModel
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
    }
}