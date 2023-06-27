using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities;
using TestQuala.Infrastructure.Persistence;

namespace TestQuala.Infrastructure.Repositories
{
    public class CurrencyTypeRepository : RepositoryBase<CurrencyType>, ICurrencyTypeRepository
    {
        public CurrencyTypeRepository(TestDbContext context) : base(context)
        {
        }
    }
}