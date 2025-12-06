using SciezkaPrawa.Application.ReadingVotes.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.ReadingVotes
{
    public interface IActReadingVotesService
    {
        Task<ActReadingVote> CreateAsync(Guid actId, SaveActReadingVoteDto dto);
        Task<ActReadingVote> GetByIdAsync(Guid actId, Guid voteId);
        Task UpdateAsync(Guid actId, Guid voteId, SaveActReadingVoteDto dto);
        Task DeleteAsync(Guid actId, Guid voteId);
    }
}
