using AutoMapper;
using Crea.SporHojam.ApplicationProcess.Domain.Models;

namespace Crea.SporHojam.ApplicationProcess.Api.Model.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Role, RoleDto>()
               .ForMember(x => x.Id, opt => opt.MapFrom(y => y.RoleId))
               .ForMember(x => x.Name, opt => opt.MapFrom(y => y.RoleName));

            CreateMap<RoleDto, Role>()
              .ForMember(x => x.RoleId, opt => opt.MapFrom(y => y.Id))
              .ForMember(x => x.RoleName, opt => opt.MapFrom(y => y.Name));
        }
    }
}
