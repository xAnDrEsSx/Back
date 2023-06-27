using AutoMapper;
using TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore;
using TestQuala.Application.Features.BranchStores.Commands.UpdateBranchStore;
using TestQuala.Application.Features.BranchStores.Queries.GetBranchStores;
using TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes;
using TestQuala.Domain.Entities;

namespace TestQuala.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BranchStore, BranchStoreVM>();
            CreateMap<CurrencyType, CurrencyTypeVM>();
            CreateMap<CreateBranchStoreCommand, BranchStore>();
            CreateMap<UpdateBranchStoreCommand, BranchStore>();
        }
    }
}