using AutoMapper;
using AutoMapperTests.DTOs;
using AutoMapperTests.Models;

namespace AutoMapperTests.Profiles
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<ParentModel, ParentDTO>();
            CreateMap<ChildModel, ChildDTO>().IncludeAllDerived();
            CreateMap<DerivedChildModel, DerivedChildDTO>(); //.IncludeBase<ChildModel, ChildDTO>(); // this is not neede as IncludeAllDerived above fixes this issue
        }
    }
}
