using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Models
{
    public struct Clothing
    {
        public string Title { get; set; }
        public float Size { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Link { get; set; }

        public Clothing(string title, float size, float price)
        {
            Title = title;
            Size = size;
            Price = price;
            Link = "";
            Description = "";
        }

        public Clothing(string title, float size, float price, string link, string description)
        {
            Title = title;
            Size = size;
            Price = price;
            Link = link;
            Description = description;
        }
    }
}
