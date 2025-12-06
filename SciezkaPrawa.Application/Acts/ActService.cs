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

        public async Task DeleteAsync(Guid id)
        {
            var act = await actRepository.GetByIdAsync(id);

            if (act is null)
                throw new NotFoundException(nameof(Act), id.ToString());

            await actRepository.DeleteAsync(act);
            await actRepository.SaveChangesAsync();
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

        public async Task UpdateAsync(Guid id, SaveActDto dto)
        {
            var act = await actRepository.GetByIdAsync(id);

            if (act is null)
                throw new NotFoundException(nameof(Act), id.ToString());

            act.Title = dto.Title;
            act.Summary = dto.Summary;
            act.Status = dto.Status;
            act.Priority = dto.Priority;
            act.Urgency = dto.Urgency;
            act.Committee = dto.Committee;
            act.Sponsor = dto.Sponsor;
            act.HasConsultation = dto.HasConsultation;
            act.ConsultationStart = dto.ConsultationStart;
            act.ConsultationEnd = dto.ConsultationEnd;
            act.AmendmentsCount = dto.AmendmentsCount;
            act.LastUpdated = DateTime.UtcNow;

            act.Tags.Clear();
            if (dto.TagIds is { Count: > 0 })
            {
                foreach (var tagId in dto.TagIds.Distinct())
                {
                    act.Tags.Add(new ActTag
                    {
                        ActId = act.Id,
                        TagId = tagId
                    });
                }
            }

            await actRepository.SaveChangesAsync();
        }
    }
}
