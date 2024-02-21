using Electing_API.Service.Dtos.Election.Request;
using Electing_API.Service.Dtos.Election.Response;
using Electing_API.Service.Handlers;
using Electing_API.Service.Results;
using Electing_API.Database.Repositories.Election;

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
        /// Create instance of ElectionRequestHandler
        /// </summary>
        /// <param name="electionRepository"></param>
        public ElectionRequestHandler(IElectionRepository electionRepository)
        {
            this.electionRepository = electionRepository;
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

                var electionEntity = new Database.Domain.Dbo.Election()
                {
                    IdentityCardId = request.IdentityCardId,
                    Name = request.Name,
                    LastName = request.LastName
                };

                electionRepository.Insert(electionEntity);
                await electionRepository.SaveAsync();
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
