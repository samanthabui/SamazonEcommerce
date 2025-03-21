//MAUI: CONTENT PAGE SERVICE VIEW MODEL
using System;
using System.Collections.ObjectModel;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

//SERVICES  
namespace Maui.eCommerce.ViewModels
{
    public class ShoppingManagementViewModel
    {
        private ProductServiceProxy _invSvc = ProductServiceProxy.Current;
        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(_invSvc.Products);
            }   
        }
    }
} 