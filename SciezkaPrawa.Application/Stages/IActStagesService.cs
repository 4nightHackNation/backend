using SciezkaPrawa.Application.Stages.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Stages
{
    public interface IActStagesService
    {
        Task<ActStage> CreateAsync(Guid actId, SaveActStageDto dto);
        Task UpdateAsync(Guid actId, Guid stageId, SaveActStageDto dto);
        Task DeleteAsync(Guid actId, Guid stageId);
    }
}
