//SAMANTHA BUI
//ECOMMERCE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samazon.Models
{
   public class Product
    {
        //TRADITIONAL GETTERS AND SETTERS
        //PROPERTY GETTERS AND SETTERS
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Display
        {
            get
            {
                //FORMAT STRING
                return $"{ID}. {Name}";
            }
        }

        public Product()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}