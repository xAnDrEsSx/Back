using MediatR;
using TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Queries.GetBranchStores
{
    public class GetBranchStoresQuery : IRequest<ResponseModel<List<BranchStoreVM>>> 
    {
    }
}