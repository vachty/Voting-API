using AutoMapper;
using Voting_API.Database.Domain.Dbo;
using Voting_API.Service.Dtos.Candidate.Response;

namespace Voting_API.Service.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Candidate, CandidateResponseDto>().ReverseMap();
        }
    }
}
