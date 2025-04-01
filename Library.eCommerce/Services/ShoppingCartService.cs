//CART MANAGEMENT SERVICE PROXY
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using Samazon.Models;

//SINGLETON: TYPE SHOPPING CART SERVICE. CAN ONLY GET ONE INSTANCE OF AN OBJECT OF THIS TYPE. 
//SINGLETON: NEED CONTROL CONSTRUCTION OF TYPE. 
namespace Library.eCommerce.Services
{
    //NEED PUBLIC TO USE.
    public class ShoppingCartService
    {
        //private ProductServiceProxy _prodSvc;
        private ProductServiceProxy _prodSvc = ProductServiceProxy.Current;
        private List<Item> items;
        public List<Item> CartItems
        {
            get
            {
                return items;
            }
        }

        //NEED L VALUE TO STORE SHOPPING CART SERVICE.
        //TO CALL FUNCTION MEMBER, YOU NEED OBJECT OF CLASS. STATIC ALLOWS TO CALL FUNCTION MEMBER, WITHOUT OBJECT OF CLASS.
        public static ShoppingCartService Current 
        {
            get
            {
                if(instance == null)
                {
                    instance = new ShoppingCartService();
                }
                return instance;
            }
        }

        private static ShoppingCartService? instance;

        //NEED PRIVATE CONSTRUCTOR. 
        private ShoppingCartService()
        {
            items = new List<Item>();
        }

        //CART MANAGEMENT: PURCHASE
        public Item? AddOrUpdate(Item item)
        {
            //ERROR HANDLE: ENSURES QUANTITY 
            var existingInvItem = _prodSvc.GetById(item.ID);
            if(existingInvItem == null || existingInvItem.Quantity == 0)
            {
                return null;
            }
            if(existingInvItem != null)
            {
                existingInvItem.Quantity--;
            }

            var existingItem = CartItems.FirstOrDefault(i => i.ID == item.ID);
            //ADD IF NO EXIST
            if(existingItem == null)
            { 
                //INIT QUANTITY TO 1; 
                var newItem = new Item(item);
                newItem.Quantity = 1;
                CartItems.Add(newItem);
            }
            
            //UPDATE IF EXIST
            else
            {
                existingItem.Quantity++; 
            }
            return existingInvItem;
        }
        
        //CART MANAGEMENT: PURCHASE RETURN. 
        //INSTEAD OF MODIFYING ADDTOCART AND BREAKING INVENTORYMANAGEMENT, MAKE NEW FUNCTION PURCHASEITEM.
        public Item ReturnItem(Item? item)
        {
            if(item?.ID <= 0 || item == null) 
            {
                return null;
            }

            //var itemToPurchase = GetById(item.ID);
            var itemToReturn = CartItems.FirstOrDefault(c => c.ID == item.ID);
            if(itemToReturn != null)
            {
                itemToReturn.Quantity--;
                var inventoryItem = _prodSvc.Products.FirstOrDefault(p => p.ID == itemToReturn.ID);
                if(inventoryItem == null)
                {
                    _prodSvc.AddOrUpdate(new Item(itemToReturn));
                }
                else
                {
                    inventoryItem.Quantity++;
                }
            }

            return itemToReturn;
        }
    }
}
