//SAMANTHA BUI
//SAMAZON ECOMMERCE APP I

//USING
using System;

//NAMESPACE DEVELOP LIBRARY MODEL
namespace Samazon.Models
{
    //PUBLIC CLASS MODEL
    public class Product
    {
        //PUBLIC PROPERTY GETTERS AND SETTERS
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Display
        {
            get
            {
                //RETURN FORMAT STRING
                return $"{ID}. {Name}";
            }
        }

        //PUBLIC CONSTRUCTOR INITIALIZES NAME TO EMPTY STRING
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
