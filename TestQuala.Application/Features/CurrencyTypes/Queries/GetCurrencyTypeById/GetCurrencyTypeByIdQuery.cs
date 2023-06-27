using MediatR;
using TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypeById
{
    public class GetCurrencyTypeByIdQuery : IRequest<ResponseModel<CurrencyTypeVM>>
    {
        public Guid Id { get; set; }
    }
}
