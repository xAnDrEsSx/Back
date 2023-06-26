using MediatR;
using TestQuala.Domain.Entities;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore
{
    public class CreateBranchStoreCommand : IRequest<ResponseModel<BranchStore>>
    {
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public Guid CurrencyTypeId { get; set; }
    }
}
