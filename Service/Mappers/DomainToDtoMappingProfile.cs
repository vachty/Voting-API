using AutoMapper;
using Domain.Dbo;
using Service.Dtos.Candidate.Response;

namespace Service.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        { 
            CreateMap<Candidate, CandidateResponseDto>();
        }
    }
}
