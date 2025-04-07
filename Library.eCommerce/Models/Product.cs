//PRODUCT MODEL

using System;
using Library.eCommerce.Models.DTO;

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

        //DTO
        public string LegacyProperty1 { get; set; }
        public string LegacyProperty2 { get; set; }
        public string LegacyProperty3 { get; set; }
        public string LegacyProperty4 { get; set; }
        public string LegacyProperty5 { get; set; }
        public string LegacyProperty6 { get; set; }

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

        //DTO
        public Product(ProductDTO p)
        {
            Name = p.Name;
            ID = p.ID;
            LegacyProperty1 = string.Empty;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}
