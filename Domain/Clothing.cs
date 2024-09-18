using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Clothing
    {

        public Clothing()
        {
        }
        public Clothing(int id, string name, string description, decimal price, string category, string size, string material, string img)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Size = size;
            Material = material;
            string image = img;

        }
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public string? Category { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Image { get; set; }
    }
}

