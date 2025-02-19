//SAMANTHA BUI
//ECOMMERCE

using Samazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.Services
{
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

        //YOU USE ID INCREMENT TO TELL IF ADD OR UPDATE FUNCTION IS UTILIZED.
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

        //QUESTION MARK MAKES NULLABLE.
        private static ProductServiceProxy? instance;
        private static object instanceLock = new object();

        //CURRENT SIGN OF SINGLETON.
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

        //NO PUBLIC DATA MEMBER, ANYONE MAY MODIFY
        public List<Product?> list;

        //LAMBDA VERSION OF GETTER. LIMITING ACCESS THE SAME WAY GETTERS LIMIT ACCESS.
        //public List<Product?> Products => list;
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