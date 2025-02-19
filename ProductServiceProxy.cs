//SAMANTHA BUI
//SAMAZON ECOMMERCE APP I

//USING
using System;
using Samazon.Models;

//NAMESPACE
namespace Library.eCommerce.Services
{
    //PUBLIC CLASS SERVICE
    public class ProductServiceProxy
    {
        //PRIVATE CONSTRUCTOR FOR SERVICE PROXY, LIMIT TIMES IT MAY BE CREATED TO ONE.
        private ProductServiceProxy()
        {
            Products = new List<Product?>            
            {
                new Product{ID = 1, Name ="Product 1"},
                new Product{ID = 2, Name ="Product 2"},
                new Product{ID = 3, Name ="Product 3"}
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
        public static ProductServiceProxy Current
        {
            get
            {
                //LOCK AND SEMAPHORE. 
                lock(instanceLock)
                if(instance == null)
                {
                    instance = new ProductServiceProxy();
                }
                return instance;
            }
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
