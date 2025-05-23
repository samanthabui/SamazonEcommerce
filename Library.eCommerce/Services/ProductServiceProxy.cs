//PRODUCT SERVICE PROXY

using System;
using System.Runtime.CompilerServices;
using Library.eCommerce.Models;
using Library.eCommerce.Models.DTO;
using Samazon.Models;

//NAMESPACE DEVELOP LIBRARY SERVICE
namespace Library.eCommerce.Services
{
    //PUBLIC CLASS PRODUCT SERVICE PROXY - IMPLEMENTS INVENTORY CRUD FUNCTIONS
    public class ProductServiceProxy
    {
        //PRIVATE CONSTRUCTOR FOR SERVICE PROXY, LIMIT TIMES IT MAY BE CREATED TO ONE.
        private ProductServiceProxy()
        {
            //INITIALIZE PRODUCT OBJECT
            Products = new List<Item?>            
            {
                //DTO
                new Item{ Product = new ProductDTO{ID = 1, Name ="PILOT LOGBOOK"}, ID = 1, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 2, Name ="AVIATION HEADPHONES"}, ID = 2, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 3, Name ="AVIATOR SUNGLASSES"}, ID = 3, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 4, Name ="FLIGHT BAG"}, ID = 4, Quantity = 10}
            };
        }

        //PUBLIC COUNTER ID INCREMENT TO TELL IF ADD OR UPDATE FUNCTION IS UTILIZED.
        private int LastKey
        {
            get
            {
                //.Count == 0 EXPRESION IF EMPTY LIST
                //!.ANY() EXPRESSION IF EMPTY LIST
                if(!Products.Any())
                {
                    return 0;
                }
                //return Products.Count; EXPRESSION MODIFICATIONS WILL INCREMENT INACCURATELY.
                //return Products.Select; EXPRESSION TAKES ID OFF, RETURNS LIST.
                return Products.Select(p => p?.ID ?? 0).Max();
            }
        }

        //PUBLIC STATIC SERVICE CURRENT SINGLETON.
        private static ProductServiceProxy? instance;
        private static object instanceLock = new object();

        //PUBLIC STATIC PROPERTY TO ACCESS THE SINGLETON INSTANCE
        public static ProductServiceProxy Current
        {
            get
            {
                //LOCK AND SEMAPHORE TO PREVENT MULTIPLE INSTANCES
                lock(instanceLock)
                {//RESOLUTION
                    if(instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                    return instance;
                }
            }
        } 

        //PUBLIC LIST
        public List<Product?> list;

        //LAMBDA VERSION OF GETTER. LIMITING ACCESS THE SAME WAY GETTERS LIMIT ACCESS.
        public List<Item?> Products { get; private set; }

        //PRODUCT ADD OR UPDATE FUNCTION
        public Item AddOrUpdate(Item item)
        {
            //YOU USE ID INCREMENT TO TELL IF ADD OR UPDATE FUNCTION IS UTILIZED.
            if(item.ID == 0)
            {
                item.ID = LastKey + 1;
                item.Product.ID = item.ID;
                Products.Add(item);
            }
            //DEEP COPY: SHALLOW COPY MODIFIED, DEEP COPY NOT MODIFIED. MODIFY DIRECTLY IN PRODUCTSERVICEPROXY.
            //DEEP COPY: FIND ALL WITH SAME ID, DEEP COPY MODIFIED.
            else
            {
                var existingItem = Products.FirstOrDefault(p => p.ID == item.ID);            
                var index = Products.IndexOf(existingItem);
                Products.RemoveAt(index); 
                Products.Insert(index, new Item(item));
            }
            return item;
        }
        
        //PRODUCT DELETE FUNCTION
        public Item? Delete(int ID)
        {
            if(ID == 0)
            {
                return null;
            }

            Item? product = Products.FirstOrDefault(p => p.ID == ID);
            Products.Remove(product);

            return product;
        }

        //EDIT: GO TO SERVICE PROXY, GET REF BY ID, WHERE PRODUCT ID MATCHES INPUT ID.
        //EDIT: SHALLOW COPY V DEEP COPY, SHALLOW COPY TO UPDATE.
        public Item? GetById(int id)
        {
            return Products.FirstOrDefault(p => p.ID == id);
        }
    }
}
