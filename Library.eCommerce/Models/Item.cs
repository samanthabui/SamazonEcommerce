//CART MANAGEMENT MODEL
using Library.eCommerce.Models.DTO;
using Library.eCommerce.Services;
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
    //CART MANAGEMENT: IN LINE BUTTON USING ICOMMAND.
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
        //CART MANAGEMENT: IN LINE BUTTON USING ICOMMAND.
        AddCommand = new Command(DoAdd);
    }

    //CART MANAGEMENT: IN LINE BUTTON USING ICOMMAND.
    private void DoAdd()
    {
        //var updatedItem = _cartSvc.AddOrUpdate(SelectedItem);
        //private ShoppingCartService _cartSvc = ShoppingCartService.Current;
        ShoppingCartService.Current.AddOrUpdate(this);
    }

    //COPY CONSTRUCTOR FOR ITEM WILL CALL COPY CONSTRUCTOR FOR PRODUCT. DEEP COPY FOR ITEM WILL USE DEEP COPY FOR PRODUCT.  
    public Item(Item i) 
    { 
        //Product = i.Product;
        //DTO
        Product = new ProductDTO(i.Product);
        Quantity = i.Quantity;
        ID = i.ID;
        //CART MANAGEMENT: IN LINE BUTTON USING ADDCOMMAND
        AddCommand = new Command(DoAdd);

    }
}
