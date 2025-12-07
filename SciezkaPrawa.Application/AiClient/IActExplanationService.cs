using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.AiClient
{
    public interface IActExplanationService
    {
        Task<string> GeneratePlainLanguageExplanationAsync(Guid actId, Guid? versionId = null);
    }
}
