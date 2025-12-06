using SciezkaPrawa.Application.ReadingVotes.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.ReadingVotes
{
    public class ActReadingVotesService(IActReadingVoteRepository votesRepo,
         IActRepository actRepo) : IActReadingVotesService
    {
        public async Task<ActReadingVote> CreateAsync(Guid actId, SaveActReadingVoteDto dto)
        {
            var act = await actRepo.GetByIdAsync(actId)
                      ?? throw new NotFoundException(nameof(Act), actId.ToString());

            var vote = new ActReadingVote
            {
                Id = Guid.NewGuid(),
                ActId = actId,
                ReadingName = dto.ReadingName,
                For = dto.For,
                Against = dto.Against,
                Abstain = dto.Abstain,
                Date = dto.Date
            };

            await votesRepo.AddAsync(vote);
            return vote;
        }

        public async Task<ActReadingVote> GetByIdAsync(Guid actId, Guid voteId)
        {
            var vote = await votesRepo.GetByIdAsync(voteId);
            if (vote is null || vote.ActId != actId)
                throw new NotFoundException(nameof(ActReadingVote), voteId.ToString());

            return vote;
        }

        public async Task UpdateAsync(Guid actId, Guid voteId, SaveActReadingVoteDto dto)
        {
            var vote = await votesRepo.GetByIdAsync(voteId);
            if (vote is null || vote.ActId != actId)
                throw new NotFoundException(nameof(ActReadingVote), voteId.ToString());

            vote.ReadingName = dto.ReadingName;
            vote.For = dto.For;
            vote.Against = dto.Against;
            vote.Abstain = dto.Abstain;
            vote.Date = dto.Date;

            await votesRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid actId, Guid voteId)
        {
            var vote = await votesRepo.GetByIdAsync(voteId);
            if (vote is null || vote.ActId != actId)
                throw new NotFoundException(nameof(ActReadingVote), voteId.ToString());

            await votesRepo.DeleteAsync(vote);
        }
    }
}
