﻿using MediatR;
using TestQuala.Domain.Entities.Common;
using TestQuala.Domain.Entities;

namespace TestQuala.Application.Features.BranchStores.Commands.UpdateBranchStore
{
    public class UpdateBranchStoreCommand : IRequest<ResponseModel<BranchStore>>
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public Guid CurrencyTypeId { get; set; }
    }
}
