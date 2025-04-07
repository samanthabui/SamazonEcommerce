//CART MANAGEMENT MODEL
using Library.eCommerce.Models.DTO;
using Samazon.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.eCommerce.Models;

public class Item
{
    public int ID { get; set; }
    //DTO
    public ProductDTO Product { get; set; }
    //MAKE DEEP COPY V SHALLOW COPY. BOUNDARY DRAWING. AGGREGATING. RAILS ON SYSTEM FOR PEOPLE.
    public int? Quantity { get; set; }

    //MAINTAIN ARCHITECTURAL PURITY, BASTARDIZE PURIST ARCHITECTURE TO EXPERIENCE THEN REFRACTOR.
    //DTO
    public ICommand? AddCommand { get; set; }

    public override string ToString()
    {
        return $"{Product} Quantity:{Quantity}";
    }

    public string Display
    {
        get
        {
            return $"{Product?.Display ?? string.Empty} {Quantity}";
        }
    }

    //DEFAULT CONSTRUCTOR. 
    public Item()
    {
        //DTO
        Product = new ProductDTO();
        Quantity = 0;
    }

    //COPY CONSTRUCTOR FOR ITEM WILL CALL COPY CONSTRUCTOR FOR PRODUCT. DEEP COPY FOR ITEM WILL USE DEEP COPY FOR PRODUCT.  
    public Item(Item i) 
    { 
        //Product = i.Product;
        //DTO
        Product = new ProductDTO(i.Product);
        Quantity = i.Quantity;
        ID = i.ID;

        //AddCommand = new Command(DoAdd);

    }
}
