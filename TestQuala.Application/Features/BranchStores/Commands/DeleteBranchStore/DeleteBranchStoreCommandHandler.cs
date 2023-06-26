using AutoMapper;
using MediatR;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Commands.DeleteBranchStore
{
    public class DeleteBranchStoreCommandHandler : IRequestHandler<DeleteBranchStoreCommand, ResponseModel<bool>>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly IMapper _mapper;

        public DeleteBranchStoreCommandHandler(IBranchStoreRepository _branchStoreRepository, IMapper _mapper)
        {
            this._branchStoreRepository = _branchStoreRepository;
            this._mapper = _mapper;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteBranchStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branchDelete = _branchStoreRepository.GetByIdAsync(request.Id);

                if (branchDelete.Result == null)
                {
                    return new ResponseModel<bool>($"Branch Store with Id: {request.Id} does not exist");
                }
                await _branchStoreRepository.DeleteAsync(branchDelete.Result);
                return new ResponseModel<bool>(true,"BranchStore deleted!");
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>(ex.Message);
            }
        }
    }
}
