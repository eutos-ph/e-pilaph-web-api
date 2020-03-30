using AutoMapper;
using Epila.Ph.WebApi.Data.Entity;
using Epila.Ph.WebApi.DTO;
using Epila.Ph.WebApi.DTO.Response;
using Epila.Ph.WebApi.DTO.Request;

namespace Epila.Ph.WebApi.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
        }
    }
}
