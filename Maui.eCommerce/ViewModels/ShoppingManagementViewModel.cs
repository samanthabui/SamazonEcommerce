//MAUI: CONTENT PAGE CART MANAGEMENT VIEW MODEL
using Library.eCommerce.Models;
using Library.eCommerce.Services;
using Samazon.Models;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

//CART MANAGMENT  
namespace Maui.eCommerce.ViewModels
{
    //CART MANAGMENT: PURCHASE INTERFACE INOTIFYPROPERTYCHANGED ALLOWS XAML TO UNDERSTAND WHEN PROPERTY HAS CHANGED.
    public class ShoppingManagementViewModel: INotifyPropertyChanged
    {
        private ProductServiceProxy _invSvc = ProductServiceProxy.Current;
        private ShoppingCartService _cartSvc = ShoppingCartService.Current;
        //CART MANAGMENT: PURCHASE
        public Item? SelectedItem { get; set; }
        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(_invSvc.Products);
            }   
        }

        //CART MANAGMENT: PURCHASE
        public event PropertyChangedEventHandler? PropertyChanged;
        //ADD [CallerMemberName] CODE SELF ACTUALIZATION. PASSING IN NAME OF WHATEVER CALLED IT.
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null){
                throw new ArgumentException(nameof(PropertyChanged));
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //CART MANAGMENT: PURCHASE
        public void PurchaseItem ()
        {
            if(SelectedItem != null)
            {
                var updatedItem = _cartSvc.AddOrUpdate(SelectedItem);
                if(updatedItem != null && updatedItem.Quantity > 0)
                {
                    NotifyPropertyChanged(nameof(Inventory));
                }
            }
        }
    }
} 
