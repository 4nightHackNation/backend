using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Act> ActList { get; set;} 
    }
}
