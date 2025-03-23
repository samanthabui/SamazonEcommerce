//SERVICES
using System;
using Samazon.Models;

namespace Library.eCommerce.Models;

public class Item
{
    public int ID { get; set; }
    public Product Product { get; set; }
    //MAKE DEEP COPY V SHALLOW COPY. BOUNDARY DRAWING. AGGREGATING. RAILS ON SYSTEM FOR PEOPLE.
    public int? Quantity { get; set; }

    public override string ToString()
    {
        return $"{Product} Quantity:{Quantity}";
    }

    public string Display
    {
        get
        {
            return Product?.Display ?? string.Empty;
        }
    }
    //DEFAULT CONSTRUCTOR. 
    public Item()
    {
        Product = new Product();
    }

    //COPY CONSTRUCTOR FOR ITEM WILL CALL COPY CONSTRUCTOR FOR PRODUCT. DEEP COPY FOR ITEM WILL USE DEEP COPY FOR PRODUCT.  
    public Item(Item i)
    {
        //Product = i.Product;
        Product = new Product(i.Product);
        Quantity = i.Quantity;
        ID = i.ID;

    }
}
