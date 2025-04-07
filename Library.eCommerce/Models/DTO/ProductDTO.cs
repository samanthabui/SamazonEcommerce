//DTO
using System;
using Samazon.Models;

namespace Library.eCommerce.Models.DTO;

public class ProductDTO
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

        public string LegacyProperty1 { get; set; }
        public string LegacyProperty2 { get; set; }
        public string LegacyProperty3 { get; set; }
        public string LegacyProperty4 { get; set; }
        public string LegacyProperty5 { get; set; }
        public string LegacyProperty6 { get; set; }
 
        //PUBLIC CONSTRUCTOR INITIALIZES NAME TO EMPTY STRING
        public ProductDTO()
        {
            Name = string.Empty;
        }

        //COPY CONSTRUCTOR FOR ITEM WILL CALL COPY CONSTRUCTOR FOR PRODUCT. DEEP COPY FOR ITEM WILL USE DEEP COPY FOR PRODUCT.
        public ProductDTO(ProductDTO p)
        {
            Name = p.Name;
            ID = p.ID;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
}
