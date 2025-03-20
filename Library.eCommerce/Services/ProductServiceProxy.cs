///SAMANTHA BUI
//SAMAZON ECOMMERCE APP I

//USING
using System;

using Samazon.Models;

//NAMESPACE DEVELOP LIBRARY SERVICE
namespace Library.eCommerce.Services
{
    //PUBLIC CLASS PRODUCT SERVICE PROXY - IMPLEMENTS INVENTORY CRUD FUNCTIONS.
    public class ProductServiceProxy
    {
        //PRIVATE CONSTRUCTOR FOR SERVICE PROXY, LIMIT TIMES IT MAY BE CREATED TO ONE.
        private ProductServiceProxy()
        {
            //INITIALIZE PRODUCT OBJECT
            Products = new List<Product?>            
            {
                new Product{ID = 1, Name ="PILOT LOGBOOK"},
                new Product{ID = 2, Name ="AVIATION HEADPHONES"},
                new Product{ID = 3, Name ="AVIATOR SUNGLASSES"},
                new Product{ID = 4, Name ="FLIGHT BAG"}
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
                if(instance == null)
                {
                    instance = new ProductServiceProxy();
                }
                return instance;
            }
        }

        //EDIT: GO TO SERVICE PROXY, GET REF BY ID, WHERE PRODUCT ID MATCHES INPUT ID.
        //EDIT: SHALLOW COPY V DEEP COPY, SHALLOW COPY TO UPDATE.

        public Product? GetById(int id)
        {
            return Products.FirstOrDefault(p => p.ID == id);
        }

        //PUBLIC LIST
        public List<Product?> list;

        //LAMBDA VERSION OF GETTER. LIMITING ACCESS THE SAME WAY GETTERS LIMIT ACCESS.
        public List<Product?> Products { get; private set; }

        //PRODUCT ADD OR UPDATE FUNCTION
        public Product AddOrUpdate(Product product)
        {
            //YOU USE ID INCREMENT TO TELL IF ADD OR UPDATE FUNCTION IS UTILIZED.
            if(product.ID == 0)
            {
                product.ID = LastKey + 1;
                Products.Add(product);
            }
            return product;
        }
        
        //PRODUCT DELETE FUNCTION
        public Product Delete(int ID)
        {
            if(ID == 0)
            {
                return null;
            }

            Product? product = Products.FirstOrDefault(p => p.ID == ID);
            Products.Remove(product);

            return product;
        }
    }
}
