using MassTransit;
using Shared.Contracts;
using Voting_API.Database.Domain.Dbo;
using Voting_API.Database.Repositories.Candidate;

namespace Voting_API.Service.Consumers
{
    /// <summary>
    /// The Election created consumer
    /// </summary>
    public sealed class ElectionCreatedConsumer : IConsumer<ElectionCreatedEvent>
    {
        /// <summary>
        /// The candidate repository
        /// </summary>
        private readonly ICandidateRepository candidateRepository;

        /// <summary>
        /// Create instance of ElectionCreatedConsumer
        /// </summary>
        /// <param name="candidateRepository"></param>
        public ElectionCreatedConsumer(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        /// <summary>
        /// Consumes the ElectionCreatedEvent
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<ElectionCreatedEvent> context)
        {
            try
            {
                var updatesCandidates = new List<Candidate>();

                if (!string.IsNullOrEmpty(context.Message.UpVotes))
                {
                    var splittedUpVotes = new List<int>(context.Message.UpVotes.Split("|").Select(int.Parse));

                    var candidatesResult = await candidateRepository.GetCandidateByVoteNumbers(splittedUpVotes);
                    if (!candidatesResult.Any())
                    {
                        throw new InvalidOperationException("No candidates for requested numbers!");
                    }

                    foreach (var candidate in candidatesResult)
                    {
                        candidate.Votes++;
                        updatesCandidates.Add(candidate);
                    }
                }
                if (!string.IsNullOrEmpty(context.Message.DownVotes))
                {
                    var splittedDownVotes = new List<int>(context.Message.DownVotes.Split("|").Select(int.Parse));

                    var candidatesResult = await candidateRepository.GetCandidateByVoteNumbers(splittedDownVotes);
                    if (!candidatesResult.Any())
                    {
                        throw new InvalidOperationException("No candidates for requested numbers!");
                    }

                    foreach (var candidate in candidatesResult)
                    {
                        candidate.Votes--;
                        updatesCandidates.Add(candidate);
                    }
                }

                if(updatesCandidates.Any()) 
                {
                    candidateRepository.UpdateMany(updatesCandidates);
                    await candidateRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}