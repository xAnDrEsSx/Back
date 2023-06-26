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
