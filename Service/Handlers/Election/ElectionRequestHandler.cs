using Infrastructure.Database.Repositories.Candidate;
using Infrastructure.Database.Repositories.Election;
using Service.Dtos.Election.Request;
using Service.Dtos.Election.Response;
using Service.Results;

namespace Service.Handlers.Election
{
    /// <summary>
    /// The Election request handler
    /// </summary>
    public class ElectionRequestHandler : BaseHandler<ElectionRequestDto, ElectionResponseDto>
    {
        /// <summary>
        /// The Candidate repository
        /// </summary>
        private readonly ICandidateRepository candidateRepository;

        /// <summary>
        /// The Election repository
        /// </summary>
        private readonly IElectionRepository electionRepository;

        /// <summary>
        /// Create instance of ElectionRequestHandler
        /// </summary>
        /// <param name="candidateRepository"></param>
        public ElectionRequestHandler(ICandidateRepository candidateRepository, IElectionRepository electionRepository)
        {
            this.candidateRepository = candidateRepository;
            this.electionRepository = electionRepository;
        }

        /// <inheritdoc/>
        public override async Task<IApiResult<ElectionResponseDto>> Handle(ElectionRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ApiResult<ElectionResponseDto>();

            try
            {
                if(string.IsNullOrEmpty(request.IdentityCardId) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.LastName))
                {
                    result.ErrorCode = "400";
                    result.AddError(new Exception("One of the required fields is empty!"));

                    return result;
                }

                var election = await electionRepository.GetElectionByIdentityCardId(request.IdentityCardId);
                if(election != null)
                {
                    result.ErrorCode = "403";
                    result.AddError(new Exception("Person can not vote more than once !"));

                    return result;
                }

                var candidatesResult = await candidateRepository.GetCandidateByVoteNumbers(request.CandidateNumbers);
                if (!candidatesResult.Any())
                {
                    result.ErrorCode = "400";
                    result.AddError(new Exception("No candidate found for election, bad candidate numbers!"));

                    return result;
                }

                foreach(var candidateEntity in candidatesResult)
                {
                    candidateEntity.Votes++;
                }

                candidateRepository.UpdateMany(candidatesResult);
                await candidateRepository.SaveAsync();

                var electionEntity = new Domain.Dbo.Election()
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
