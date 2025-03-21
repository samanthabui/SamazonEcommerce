//SERVICES  
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
        private ProductServiceProxy _prodSvc;
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
            set
            {

            }
        }

        private static ShoppingCartService? instance;

        //NEED PRIVATE CONSTRUCTOR. 
        private ShoppingCartService()
        {
            items = new List<Item>();
        }
    }
}