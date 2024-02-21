using AutoMapper;
using Voting_API.Database.Repositories.Candidate;
using Voting_API.Service.Dtos.Candidate.Request;
using Voting_API.Service.Dtos.Candidate.Response;
using Voting_API.Service.Results;

namespace Voting_API.Service.Handlers.Candidate
{
    /// <summary>
    /// The Candidate list request handler
    /// </summary>
    public class CandidateListRequestHandler : BaseHandler<CandidateListRequestDto, CandidateListResponseDto>
    {
        /// <summary>
		/// The candidate repository
		/// </summary>
		private readonly ICandidateRepository candidateRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
		/// Create instance of the handler
		/// </summary>
		/// <param name="candidateRepository"></param>
		/// <param name="mapper"></param>
		public CandidateListRequestHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public override async Task<IApiResult<CandidateListResponseDto>> Handle(CandidateListRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ApiResult<CandidateListResponseDto>();

            try
            {
                var candidatesResult = await candidateRepository.GetAllAsync();
                if (!candidatesResult.Any())
                {
                    result.AddError(new Exception("No candidate found."));
                    result.ErrorCode = "204";
                    return result;
                }

                var responseDto = new CandidateListResponseDto();
                responseDto.Candidates = mapper.Map<IList<Database.Domain.Dbo.Candidate>, IList<CandidateResponseDto>>(candidatesResult);

                result.Data = responseDto;
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