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
        //CART MANAGEMENT: PURCHASE RETURN 
        public Item? SelectedCartItem { get; set; }

        public ObservableCollection<Item?> Inventory
        {
            get
            {
                //return new ObservableCollection<Item?>(_invSvc.Products);
                return new ObservableCollection<Item?>(_invSvc.Products.Where(i => i?.Quantity > 0));
            }   
        }
 
        public ObservableCollection<Item?> ShoppingCart
        {
            get
            {
                //return new ObservableCollection<Item?>(_invSvc.Products);
                return new ObservableCollection<Item?>(_cartSvc.CartItems.Where(i => i?.Quantity > 0));
            }   
        }

        //CART MANAGMENT: PURCHASE
        public event PropertyChangedEventHandler? PropertyChanged;
        //ADD [CallerMemberName] CODE SELF ACTUALIZATION. PASSING IN NAME OF WHATEVER CALLED IT.
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null){
                //throw new ArgumentException(nameof(PropertyChanged));
                 throw new ArgumentNullException(nameof(PropertyChanged));//POSSIBLE RESOLUTION
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //CART MANAGEMENT: IN LINE BUTTON USING ICOMMAND.
        public void RefreshUX()
        {
            NotifyPropertyChanged(nameof(Inventory));
            NotifyPropertyChanged(nameof(ShoppingCart));
        }

        //CART MANAGMENT: PURCHASE
        public void PurchaseItem()
        {
            if(SelectedItem != null)
            {
                var shouldRefresh = SelectedItem.Quantity >= 1;
                var updatedItem = _cartSvc.AddOrUpdate(SelectedItem);

                //if(updatedItem != null && updatedItem.Quantity > 0)
                if(updatedItem != null && shouldRefresh)
                {
                    //ONLY WANT TO REFRESH WHEN CALLED
                    NotifyPropertyChanged(nameof(Inventory));
                    NotifyPropertyChanged(nameof(ShoppingCart));
                }
            }
        }

        //CART MANAGEMENT: PURCHASE RETURN 
        public void ReturnItem()
        {
            if(SelectedCartItem != null)
            {
                var shouldRefresh = SelectedCartItem.Quantity >= 1;
                var updatedItem = _cartSvc.ReturnItem(SelectedCartItem);

                //if(updatedItem != null && updatedItem.Quantity > 0)
                if(updatedItem != null && shouldRefresh)
                {
                    //ONLY WANT TO REFRESH WHEN CALLED
                    NotifyPropertyChanged(nameof(Inventory));
                    NotifyPropertyChanged(nameof(ShoppingCart));
                }
            }
        }
    }
}   
