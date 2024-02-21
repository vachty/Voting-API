using AutoMapper;
using Voting_API.Database.Domain.Dbo;
using Voting_API.Service.Dtos.Candidate.Response;

namespace Voting_API.Service.Mappers
{
    /// <summary>
    /// The Domain to Dto mapping profile
    /// </summary>
    public class DomainToDtoMappingProfile : Profile
    {
        /// <summary>
        /// Create instance of DomainToDtoMappingProfile
        /// </summary>
        public DomainToDtoMappingProfile()
        {
            CreateMap<Candidate, CandidateResponseDto>().ReverseMap();
        }
    }
}