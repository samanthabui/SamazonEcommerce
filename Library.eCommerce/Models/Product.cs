//PRODUCT MODEL

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

        //COPY CONSTRUCTOR FOR ITEM WILL CALL COPY CONSTRUCTOR FOR PRODUCT. DEEP COPY FOR ITEM WILL USE DEEP COPY FOR PRODUCT.
        public Product(Product p)
        {
            Name = p.Name;
            ID = p.ID;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}
