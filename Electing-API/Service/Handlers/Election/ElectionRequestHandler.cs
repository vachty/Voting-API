using AutoMapper;
using Electing_API.Database.Repositories.Election;
using Electing_API.Service.Dtos.Election.Request;
using Electing_API.Service.Dtos.Election.Response;
using Electing_API.Service.Results;
using MassTransit;
using Shared.Contracts;

namespace Electing_API.Service.Handlers.Election
{
    /// <summary>
    /// The Election request handler
    /// </summary>
    public class ElectionRequestHandler : BaseHandler<ElectionRequestDto, ElectionResponseDto>
    {
        /// <summary>
        /// The Election repository
        /// </summary>
        private readonly IElectionRepository electionRepository;

        /// <summary>
        /// The auto mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The masstransit endpoint
        /// </summary>
        private readonly IPublishEndpoint publishEndpoint;

        /// <summary>
        /// Create instance of ElectionRequestHandler
        /// </summary>
        /// <param name="electionRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="publishEndpoint"></param>
        public ElectionRequestHandler(IElectionRepository electionRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            this.electionRepository = electionRepository;
            this.mapper = mapper;
            this.publishEndpoint = publishEndpoint;
        }

        /// <inheritdoc/>
        public override async Task<IApiResult<ElectionResponseDto>> Handle(ElectionRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ApiResult<ElectionResponseDto>();

            try
            {
                if (string.IsNullOrEmpty(request.IdentityCardId) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.LastName))
                {
                    result.ErrorCode = "400";
                    result.AddError(new Exception("One of the required fields is empty!"));

                    return result;
                }

                var election = await electionRepository.GetElectionByIdentityCardId(request.IdentityCardId);
                if (election != null)
                {
                    result.ErrorCode = "403";
                    result.AddError(new Exception("Person can not vote more than once !"));

                    return result;
                }

                var electionEntity = mapper.Map<ElectionRequestDto,Database.Domain.Dbo.Election>(request);

                electionRepository.Insert(electionEntity);
                await electionRepository.SaveAsync();

                await publishEndpoint.Publish(mapper.Map<Database.Domain.Dbo.Election, ElectionCreatedEvent>(electionEntity));
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                result.ErrorCode = "500";
            }

            return result;
        }
    }
}