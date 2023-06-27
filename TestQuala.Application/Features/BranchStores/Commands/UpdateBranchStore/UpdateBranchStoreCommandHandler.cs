using MediatR;
using TestQuala.Domain.Entities.Common;
using TestQuala.Domain.Entities;
using AutoMapper;
using TestQuala.Application.Contracts.Persistence;

namespace TestQuala.Application.Features.BranchStores.Commands.UpdateBranchStore
{
    public class UpdateBranchStoreCommandHandler : IRequestHandler<UpdateBranchStoreCommand, ResponseModel<BranchStore>>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly IMapper _mapper;

        public UpdateBranchStoreCommandHandler(IBranchStoreRepository _branchStoreRepository, IMapper _mapper)
        {
            this._branchStoreRepository = _branchStoreRepository;
            this._mapper = _mapper;
        }

        public async Task<ResponseModel<BranchStore>> Handle(UpdateBranchStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = _mapper.Map<BranchStore>(request);
                var branchs = _branchStoreRepository.GetAllAsync().Result;

                if (branchs != null)
                {
                    if (branchs.Any(b => b.Description == request?.Description && b.Id != request?.Id))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con esa descripcion!");
                    }

                    if (branchs.Any(b => b.Code == request?.Code && b.Id != request?.Id))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con ese Código!");
                    }
                    if (branchs.Any(b => b.Identification == request?.Identification && b.Id != request?.Id))
                    {
                        return new ResponseModel<BranchStore>(false, "Ya existe una tienda con esa Identificacion!");
                    }
                }

                branch.LastModifiedDate = DateTime.UtcNow;
                await _branchStoreRepository.UpdateAsync(branch);
                return new ResponseModel<BranchStore>(branch, "BranchStore updated!");
            }
            catch (Exception ex)
            {
                return new ResponseModel<BranchStore>(ex.Message);
            }
        }
    }
}
