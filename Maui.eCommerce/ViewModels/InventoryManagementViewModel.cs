using Library.eCommerce.Services;
using Samazon.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerce.ViewModels
{ 
    public class InventoryManagementViewModel
    {
        //ADD PROJECT DEPENDENCY. ADD PROJECT REFERENCE TO LIBRARY AND SAMAZON.
        //MAKE NULLABILITY OF REFERENCE TYPE MATCH USING ?.
        public Product? SelectedProduct { get; set; }
        //ProductServiceProxy.Current RIGHT HAND SIDE IS REFERENCE, EASY TROUBLESHOOT.
        private ProductServiceProxy _svc = ProductServiceProxy.Current;
        public List<Product?> Products
        {
            get
            {
                return _svc.Products;
            }
        }

        //DELETE FUNCTION IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
        //GO TO VIEW MODEL AND CREATE A DELETE FUNCTION.
        public Product? Delete()
        {
            return _svc.Delete(SelectedProduct?.ID ?? 0);
        }
    }
}

//ASSIGNMENT II
//SET UP DEFAULT DATA IN PRODUCT SERVICE PROXY SO YOU UNDERSTAND WHEN BINDING HAS SUCCEEDED.
