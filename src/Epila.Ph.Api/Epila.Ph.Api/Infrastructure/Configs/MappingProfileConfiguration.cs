using AutoMapper;
using Epila.Ph.Api.Data.Entity;
using Epila.Ph.Api.DTO;
using Epila.Ph.Api.DTO.Response;
using Epila.Ph.Api.DTO.Request;

namespace Epila.Ph.Api.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonQueryResponse>().ReverseMap();
        }
    }
}
