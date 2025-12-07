using SciezkaPrawa.Application.Pdf;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.AiClient
{
    public class ActExplanationService(IActRepository actRepository,
        IActVersionRepository versionRepository,
        IAiClient aiClient,
        IPdfTextExtractor pdfTextExtractor) : IActExplanationService
    {
        public async Task<string> GeneratePlainLanguageExplanationAsync(Guid actId, Guid? versionId = null)
        {
            var act = await actRepository.GetDetailsByIdAsync(actId)
                      ?? throw new NotFoundException(nameof(Act), actId.ToString());

            ActVersion? version;

            if (versionId is null)
            {
                version = act.Versions
                    .OrderByDescending(v => v.Date)
                    .FirstOrDefault();
            }
            else
            {
                version = await versionRepository.GetByIdAsync(versionId.Value);
            }

            if (version is null)
                throw new NotFoundException(nameof(ActVersion), versionId?.ToString() ?? "latest");

            var text = pdfTextExtractor.ExtractText(version.FilePath);

            var explanation = await aiClient.SummarizeActAsync(text);

            act.PlainLanguageSummary = explanation;

            await actRepository.SaveChangesAsync();

            return explanation;

        }
    }
}
