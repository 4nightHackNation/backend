using SciezkaPrawa.Application.Versions.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Versions
{
    public class ActVersionsService(IActVersionRepository actVersionRepository,
        IActRepository actRepository
        ) : IActVersionsService
    {
        public async Task<ActVersion> CreateAsync(Guid actId, SaveActVersionDto dto)
        {
            var act = await actRepository.GetByIdAsync(actId)
                      ?? throw new NotFoundException(nameof(Act), actId.ToString());

            var version = new ActVersion
            {
                Id = Guid.NewGuid(),
                ActId = actId,
                VersionNumber = dto.VersionNumber,
                Date = dto.Date,
                Type = dto.Type,
                FilePath = dto.FilePath
            };

            await actVersionRepository.AddAsync(version);
            return version;
        }

        public async Task<ActVersion> GetByIdAsync(Guid actId, Guid versionId)
        {
            var version = await actVersionRepository.GetByIdAsync(versionId);
            if (version is null || version.ActId != actId)
                throw new NotFoundException(nameof(ActVersion), versionId.ToString());

            return version;
        }

        public async Task UpdateAsync(Guid actId, Guid versionId, SaveActVersionDto dto)
        {
            var version = await actVersionRepository.GetByIdAsync(versionId);
            if (version is null || version.ActId != actId)
                throw new NotFoundException(nameof(ActVersion), versionId.ToString());

            version.VersionNumber = dto.VersionNumber;
            version.Date = dto.Date;
            version.Type = dto.Type;
            version.FilePath = dto.FilePath;

            await actVersionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid actId, Guid versionId)
        {
            var version = await actVersionRepository.GetByIdAsync(versionId);
            if (version is null || version.ActId != actId)
                throw new NotFoundException(nameof(ActVersion), versionId.ToString());

            await actVersionRepository.DeleteAsync(version);
        }
    }
}
