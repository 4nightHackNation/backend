using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Acts
{
    public class ActService(IActRepository actRepository) : IActService
    {
        public async Task<Act> CreateAsync(SaveActDto dto)
        {
            var act = new Act
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Summary = dto.Summary,
                Status = dto.Status,
                Priority = dto.Priority,
                Urgency = dto.Urgency,
                Committee = dto.Committee,
                Sponsor = dto.Sponsor,
                HasConsultation = dto.HasConsultation,
                ConsultationStart = dto.ConsultationStart,
                ConsultationEnd = dto.ConsultationEnd,
                AmendmentsCount = dto.AmendmentsCount,
                DateSubmitted = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            if (dto.TagIds is { Count: > 0 })
            {
                act.Tags = dto.TagIds
                    .Distinct()
                    .Select(tagId => new ActTag
                    {
                        Act = act,   // EF sam przypisze ActId
                        TagId = tagId
                    })
                    .ToList();
            }

            await actRepository.AddAsync(act);
            return act;
        }

        public async Task<IEnumerable<Act>> GetAllAsync()
        {
            var acts = await actRepository.GetAllAsync();
            return (acts);
        }

        public async Task<Act?> GetById(Guid id)
        {
            var act = await actRepository.GetByIdAsync(id);

            if (act == null)
            {
                throw new NotFoundException(nameof(act), id.ToString());
            }

            return (act);
        }
    }
}
