using AutoMapper;
using MediatR;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes
{
    public class GetCurrencyTypesQueyHandler : IRequestHandler<GetCurrencyTypesQuery, ResponseModel<List<CurrencyTypeVM>>>
    {
        private readonly ICurrencyTypeRepository _currencyTypeRepository;
        private readonly IMapper _mapper;

        public GetCurrencyTypesQueyHandler(ICurrencyTypeRepository _currencyTypeRepository, IMapper _mapper)
        {
            this._currencyTypeRepository = _currencyTypeRepository;
            this._mapper = _mapper;
        }

        public async Task<ResponseModel<List<CurrencyTypeVM>>> Handle(GetCurrencyTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new ResponseModel<List<CurrencyTypeVM>>(_mapper.Map<List<CurrencyTypeVM>>(await _currencyTypeRepository.GetAllAsync()), "Lista de Tipo Moneda");

            }
            catch (Exception ex)
            {
                return new ResponseModel<List<CurrencyTypeVM>>(ex.Message);
            }
        }
    }
}
