using AutoMapper;
using MediatR;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypeById
{
    public class GetCurrencyTypeByIdQueryHandler : IRequestHandler<GetCurrencyTypeByIdQuery, ResponseModel<CurrencyTypeVM>>
    {
        private readonly ICurrencyTypeRepository _currencyTypeRepository;
        private readonly IMapper _mapper;

        public GetCurrencyTypeByIdQueryHandler(ICurrencyTypeRepository _currencyTypeRepository, IMapper _mapper)
        {
            this._currencyTypeRepository = _currencyTypeRepository;
            this._mapper = _mapper;
        }

        public async Task<ResponseModel<CurrencyTypeVM>> Handle(GetCurrencyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new ResponseModel<CurrencyTypeVM>(_mapper.Map<CurrencyTypeVM>(await _currencyTypeRepository.GetByIdAsync(request.Id)), "Tipo Moneda");
            }
            catch (Exception ex)
            {
                return new ResponseModel<CurrencyTypeVM>(ex.Message);
            }
        }
    }
}
