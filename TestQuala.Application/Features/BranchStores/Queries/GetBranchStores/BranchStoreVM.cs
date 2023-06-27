namespace TestQuala.Application.Features.BranchStores.Queries.GetBranchStores
{
    public class BranchStoreVM
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string CurrencyType { get; set; } = string.Empty;
    }
}
