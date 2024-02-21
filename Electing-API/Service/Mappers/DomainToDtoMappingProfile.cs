using AutoMapper;
using Electing_API.Database.Domain.Dbo;
using Electing_API.Service.Dtos.Election.Request;
using Electing_API.Service.Dtos.Election.Response;

namespace Electing_API.Service.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<ElectionRequestDto, Election>().ReverseMap();
        }
    }
}
