//MAUI: CONTENT PAGE INVENTORY MANAGEMENT VIEW MODEL
using Library.eCommerce.Models;
using Library.eCommerce.Services;
using Samazon.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//BINDING MVVM: VIOLATES MVVM IF VIEW AND VIEW MODEL ARE THE SAME. THEREFORE, MAKE CLASS NAMED MAINVIEWMODEL.
//BINDING MVVM: DECOUPLE THE DEPENDENCIES. HAVE THE ABILITY TO REUSE VIEWMODELS.
namespace Maui.eCommerce.ViewModels
{
    //INHERITANCE MEANS OBJ KEEPS ALL OF PARENTS. PARTIAL MAKES SURE PART OF CLASS DEF IN XAML AND PART DEF IN C#.
    //ADD: INTERFACE INOTIFYPROPERTYCHANGED ALLOWS XAML TO UNDERSTAND WHEN PROPERTY HAS CHANGED.
    public class InventoryManagementViewModel: INotifyPropertyChanged
    {
        //MAKE NULLABILITY OF REFERENCE TYPE MATCH USING ?  
        public Item? SelectedProduct { get; set; }

        //SEARCH: SEARCH FUNCTION BASED ON QUERY 
        //SEARCH: ENTRY TEXT IN INVENTORY MANAGEMENT XAML SCRIPT. FUNCTION IMPLEMENTATION IN INVENTORY MANAGEMENT XAML LOGIC SearchClicked(). INVENTORY MANAGEMENT VIEWMODEL Query { get; set; }, ObservableCollection.
        public string? Query { get; set; }

        //ProductServiceProxy.Current RIGHT HAND SIDE IS REFERENCE, EASY REFERENCE.
        private ProductServiceProxy _svc = ProductServiceProxy.Current;

        public event PropertyChangedEventHandler? PropertyChanged;
        //ADD: [CallerMemberName] CODE SELF ACTUALIZATION. PASSING IN NAME OF WHATEVER CALLED IT.
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null){
                throw new ArgumentException(nameof(PropertyChanged));
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //ADD: NOTIFY PROPERTY CHANGED REFRESH LIST
        public void RefreshProductList()
        {
            //ADD: nameof() TAKES COMPIILED THING AND RETURNS STRING THAT IS NAME OF THING. 
            NotifyPropertyChanged(nameof(Products));
        }

        //ITEM SOURCE IS OBSERVABLE COLLECTION. CHANGE LIST TO OBERSERVABLE COLLECTION.
        public ObservableCollection<Item?> Products
        {
            get
            {
                var filteredList = _svc.Products.Where(p => p?.Product?.Name?.ToLower().Contains(Query?.ToLower() ?? string.Empty) ?? false);
                return new ObservableCollection<Item?>(filteredList);
            }
        }
  
        //BINDING MVVM: DELETE FUNCTION IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
        //BINDING MVVM: GO TO VIEW MODEL AND CREATE A DELETE FUNCTION.
        public Item? Delete()
        {
            var item = _svc.Delete(SelectedProduct?.ID ?? 0);
            NotifyPropertyChanged("Products");
            return item;
        }
    }
}	
