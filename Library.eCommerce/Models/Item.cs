using System;
using Samazon.Models;

namespace Library.eCommerce.Models;

public class Item
{
    public int ID { get; set; }
    public Product Product { get; set; }
    //MAKE DEEP COPY V SHALLOW COPY. BOUNDARY DRAWING. AGGREGATING. RAILS ON SYSTEM FOR PEOPLE.
    public int Quantity { get; set; }

    public string Display
    {
        get
        {
            return Product?.Display?? string.Empty;
        }
    }
    //DEFAULT CONSTRUCTOR. 

    public Item()
    {
        Product = new Product();
    }
}
