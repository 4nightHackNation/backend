using SciezkaPrawa.Application.Stages.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;


namespace SciezkaPrawa.Application.Stages
{
    public class ActStagesService(IStageRepository stageRepository,
        IActRepository actRepository) : IActStagesService
    {
        public async Task<ActStage> CreateAsync(Guid actId, SaveActStageDto dto)
        {
            var act = await actRepository.GetByIdAsync(actId);
            if (act is null)
                throw new NotFoundException(nameof(Act), actId.ToString());

            var stage = new ActStage
            {
                Id = Guid.NewGuid(),
                ActId = actId,
                Name = dto.Name,
                Date = dto.Date,
                Status = dto.Status,
                Order = dto.Order
            };

            await stageRepository.AddAsync(stage);
            return stage;
        }

        public async Task DeleteAsync(Guid actId, Guid stageId)
        {
            var stage = await stageRepository.GetByIdAsync(stageId);

            if (stage is null || stage.ActId != actId)
                throw new NotFoundException(nameof(ActStage), stageId.ToString());

            await stageRepository.DeleteAsync(stage);
        }


        public async Task UpdateAsync(Guid actId, Guid stageId, SaveActStageDto dto)
        {
            var stage = await stageRepository.GetByIdAsync(stageId);

            if (stage is null || stage.ActId != actId)
                throw new NotFoundException(nameof(ActStage), stageId.ToString());

            stage.Name = dto.Name;
            stage.Date = dto.Date;
            stage.Status = dto.Status;
            stage.Order = dto.Order;

            await stageRepository.SaveChangesAsync();
        }
    }
}
