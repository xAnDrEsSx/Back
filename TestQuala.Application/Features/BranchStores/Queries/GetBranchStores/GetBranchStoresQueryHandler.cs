using AutoMapper;
using MediatR;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Queries.GetBranchStores
{
    public class GetBranchStoresQueryHandler : IRequestHandler<GetBranchStoresQuery, ResponseModel<List<BranchStoreVM>>>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly ICurrencyTypeRepository _currencyTypeRepository;
        private readonly IMapper _mapper;

        public GetBranchStoresQueryHandler(IBranchStoreRepository _branchStoreRepository, ICurrencyTypeRepository _currencyTypeRepository, IMapper _mapper)
        {
            this._branchStoreRepository = _branchStoreRepository;
            this._currencyTypeRepository = _currencyTypeRepository;
            this._mapper = _mapper;
        }

        public Task<ResponseModel<List<BranchStoreVM>>> Handle(GetBranchStoresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(new ResponseModel<List<BranchStoreVM>>(_mapper.Map<List<BranchStoreVM>>(GetListBranchStores()), "Lista de Tiendas"));

            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseModel<List<BranchStoreVM>>(ex.Message));
            }
        }

        private List<BranchStoreVM> GetListBranchStores()
        {
            var currencyTypes = _currencyTypeRepository.GetAllAsync().Result;
            var branchs = _branchStoreRepository.GetAllAsync().Result;
            var listBranchs = new List<BranchStoreVM>();

            foreach(var branch in branchs.OrderByDescending(b => b.CreatedDate))
            {
                var currencyType = currencyTypes.Where(c => c.Id == branch.CurrencyTypeId).FirstOrDefault();

                listBranchs.Add(
                     new BranchStoreVM
                     {
                         Code = branch.Code,
                         Address = branch.Address,
                         Description = branch.Description,
                         Id = branch.Id,
                         Identification = branch.Identification,
                         CurrencyType = currencyType.CurrencyName
                     });
            }

     
            return listBranchs;
        }


    }
}
