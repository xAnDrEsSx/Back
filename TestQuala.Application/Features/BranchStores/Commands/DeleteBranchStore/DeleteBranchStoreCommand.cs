using MediatR;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Commands.DeleteBranchStore
{
    public class DeleteBranchStoreCommand : IRequest<ResponseModel<bool>>
    {
        public Guid Id { get; set; }
    }
}   