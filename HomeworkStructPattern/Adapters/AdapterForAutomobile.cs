using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkStructPattern.Models;

namespace HomeworkStructPattern.Adapters
{
    class AdapterForAutomobile : IProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Automobile Source { get; set; }

        public AdapterForAutomobile(Automobile source)
        {
            Name = source.Title;
            Price = source.Price;
            Description = source.Specification;
            Source = source;
        }
    }
}
