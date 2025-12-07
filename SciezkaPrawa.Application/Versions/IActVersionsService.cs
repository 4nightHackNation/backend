using SciezkaPrawa.Application.Versions.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Versions
{
    public interface IActVersionsService
    {
        Task<ActVersion> CreateAsync(Guid actId, SaveActVersionDto dto);
        Task<ActVersion> GetByIdAsync(Guid actId, Guid versionId);
        Task UpdateAsync(Guid actId, Guid versionId, SaveActVersionDto dto);
        Task DeleteAsync(Guid actId, Guid versionId);
        Task UploadPdfAsync(Guid actId, Guid versionId, Stream fileStream, string fileName);

    }
}
