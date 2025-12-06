using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Stages.DTOs
{
    public class SaveActStageDto
    {
        public string Name { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "planned";
        public int Order { get; set; }
    }
}

