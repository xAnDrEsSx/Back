using AutoMapper;
using MediatR;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore
{
    public class CreateBranchStoreCommandHandler : IRequestHandler<CreateBranchStoreCommand, ResponseModel<BranchStore>>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly IMapper _mapper;

        public CreateBranchStoreCommandHandler(IBranchStoreRepository _branchStoreRepository, IMapper _mapper)
        {
            this._branchStoreRepository = _branchStoreRepository;
            this._mapper = _mapper;
        }

        public async Task<ResponseModel<BranchStore>> Handle(CreateBranchStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    new ResponseModel<bool>("Error Request");
                }

                var branchs = _branchStoreRepository.GetAllAsync().Result;

                if (branchs != null)
                {
                    if (branchs.Any(b => b.Description == request?.Description))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con esa descripcion!");
                    }

                    if (branchs.Any(b => b.Code == request?.Code))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con ese Código!");
                    }
                    if (branchs.Any(b => b.Identification == request?.Identification))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con esa Identificacion!");
                    }
                }


                var newBranch = _mapper.Map<BranchStore>(request);
                await _branchStoreRepository.AddAsync(newBranch);
                return new ResponseModel<BranchStore>(newBranch, "BranchStore created!");
                    
            }catch (Exception ex )
            {
                return new ResponseModel<BranchStore>(ex.Message);
            }

        }
    }
}
