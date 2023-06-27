using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities;
using TestQuala.Infrastructure.Persistence;

namespace TestQuala.Infrastructure.Repositories
{
    public class BranchStoreRepository : RepositoryBase<BranchStore>, IBranchStoreRepository
    {
        public BranchStoreRepository(TestDbContext context) : base(context)
        {
        }
    }
}