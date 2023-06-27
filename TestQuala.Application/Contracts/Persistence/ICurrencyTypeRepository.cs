using TestQuala.Domain.Entities;

namespace TestQuala.Application.Contracts.Persistence
{
    public interface ICurrencyTypeRepository : IAsyncRepository<CurrencyType>
    {
    }
}
