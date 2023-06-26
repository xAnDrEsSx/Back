using AutoMapper;
using TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore;
using TestQuala.Domain.Entities;

namespace TestQuala.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Prestamo, GetPrestamoResonse>();
            CreateMap<CreateBranchStoreCommand, BranchStore>();
        }
    }
}