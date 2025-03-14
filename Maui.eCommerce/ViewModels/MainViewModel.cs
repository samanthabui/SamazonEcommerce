//MAUI: CONTENT PAGE INVENTORY MANAGEMENT VIEW MODEL
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
    //INTERFACE INOTIFYPROPERTYCHANGED ALLOWS XAML TO UNDERSTAND WHEN PROPERTY HAS CHANGED.
    public class InventoryManagementViewModel: INotifyPropertyChanged
    {
        //MAKE NULLABILITY OF REFERENCE TYPE MATCH USING ?.
        public Product? SelectedProduct { get; set; }
        //ProductServiceProxy.Current RIGHT HAND SIDE IS REFERENCE, EASY REFERENCE.
        private ProductServiceProxy _svc = ProductServiceProxy.Current;

        public event PropertyChangedEventHandler? PropertyChanged;
        //[CallerMemberName] CODE SELF ACTUALIZATION. PASSING IN NAME OF WHATEVER CALLED IT.
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged is null){
                throw new ArgumentException(nameof(PropertyChanged));
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //ITEM SOURCE IS OBSERVABLE COLLECTION. CHANGE LIST TO OBERSERVABLE COLLECTION.
        public ObservableCollection<Product?> Products
        {
            get
            {
                return new ObservableCollection<Product?>(_svc.Products);
            }
        }

        //BINDING MVVM: DELETE FUNCTION IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
        //BINDING MVVM: GO TO VIEW MODEL AND CREATE A DELETE FUNCTION.
        public Product? Delete()
        {
            var item = _svc.Delete(SelectedProduct?.ID ?? 0);
            NotifyPropertyChanged("Products");
            return item;
        }
    }
}
