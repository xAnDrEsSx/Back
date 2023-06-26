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
