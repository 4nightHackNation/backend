using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Application.Tags.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;

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
                        Act = act,
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
        public async Task<IEnumerable<ActListDto>> GetAllAsync()
        {
            var acts = await actRepository.GetAllAsync();

            return acts.Select(a => new ActListDto
            {
                Id = a.Id,
                Title = a.Title,
                Summary = a.Summary,
                Status = a.Status,
                Priority = a.Priority,
                Urgency = a.Urgency,
                Committee = a.Committee,
                Sponsor = a.Sponsor,
                DateSubmitted = a.DateSubmitted,
                LastUpdated = a.LastUpdated,
                HasConsultation = a.HasConsultation,
                ConsultationStart = a.ConsultationStart,
                ConsultationEnd = a.ConsultationEnd,
                AmendmentsCount = a.AmendmentsCount,
                Tags = a.Tags
                    .Select(at => new TagDto
                    {
                        Id = at.Tag.Id,
                        Name = at.Tag.Name
                    })
                    .ToList()
            });
        }

        public async Task<Act> GetById(Guid id)
        {
            var act = await actRepository.GetDetailsByIdAsync(id)
                     ?? throw new NotFoundException(nameof(Act), id.ToString());
            return act;
        }

        public async Task<ActDetailsDto> GetByIdAsync(Guid id)
        {
            var act = await actRepository.GetDetailsByIdAsync(id)
                      ?? throw new NotFoundException(nameof(Act), id.ToString());

            return new ActDetailsDto
            {
                Id = act.Id,
                Title = act.Title,
                Summary = act.Summary,
                Status = act.Status,
                Priority = act.Priority,
                Urgency = act.Urgency,
                Committee = act.Committee,
                Sponsor = act.Sponsor,
                DateSubmitted = act.DateSubmitted,
                LastUpdated = act.LastUpdated,
                HasConsultation = act.HasConsultation,
                ConsultationStart = act.ConsultationStart,
                ConsultationEnd = act.ConsultationEnd,
                AmendmentsCount = act.AmendmentsCount,

                Tags = act.Tags
                    .Select(at => new TagDto
                    {
                        Id = at.Tag.Id,
                        Name = at.Tag.Name
                    })
                    .ToList(),

                Stages = act.Stages.ToList(),
                Versions = act.Versions.ToList(),
                ReadingVotes = act.ReadingVotes.ToList()
            };
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
