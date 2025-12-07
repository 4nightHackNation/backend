using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.AiClient
{
    public interface IAiClient
    {
       Task<string> SummarizeActAsync(string actText);
    }
}
