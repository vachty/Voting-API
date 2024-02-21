using AutoMapper;
using Electing_API.Database.Domain.Dbo;
using Electing_API.Service.Dtos.Election.Request;
using Shared.Contracts;

namespace Electing_API.Service.Mappers
{
    /// <summary>
    /// The mapping profile
    /// </summary>
    public class DtoToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Create instance of DtoToDomainMappingProfile
        /// </summary>
        public DtoToDomainMappingProfile()
        {
            CreateMap<ElectionRequestDto, Election>()
             .ForMember(dest => dest.UpVotes, src =>src.MapFrom(src=> string.Join("|", src.UpVotes.Select(x=>x.ToString()).ToArray())))
             .ForMember(dest => dest.DownVotes, src =>src.MapFrom(src=> string.Join("|", src.DownVotes.Select(x=>x.ToString()).ToArray())));

            CreateMap<Election, ElectionCreatedEvent>();
        }
    }
}