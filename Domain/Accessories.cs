using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Accessories
    {
        public Accessories()
        {
        }
        public Accessories(int id, string name, string description, decimal price, string category, string image)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Image = image;
        }
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }

    }
}
