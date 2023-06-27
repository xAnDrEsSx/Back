using MediatR;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes
{
    public class GetCurrencyTypesQuery : IRequest<ResponseModel<List<CurrencyTypeVM>>>
    {
    }
}
