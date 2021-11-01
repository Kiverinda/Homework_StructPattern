using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Models
{
    public class Automobile
    {
        public string Title { get; set; }
        public string Specification { get; set; }
        public float Power { get; set; }
        public string Collor { get; set; }
        public float Price { get; set; }
        public string Link { get; set; }

        public Automobile(string title, string collor, float power, float price, string specification, string link)
        {
            Title = title;
            Collor = collor;
            Price = price;
            Power = power;
            Link = link;
            Specification = specification;
        }
    }
}
