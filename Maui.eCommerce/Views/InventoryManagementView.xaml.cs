//MAUI: CONTENT PAGE INVENTORY MANAGEMENT XAML LOGIC
using System.ComponentModel;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

//BINDING MVVM: VIOLATES MVVM IF VIEW AND VIEW MODEL ARE THE SAME. THEREFORE, MAKE CLASS NAMED MAINVIEWMODEL.
//BINDING MVVM: DECOUPLE THE DEPENDENCIES. HAVE THE ABILITY TO REUSE VIEWMODELS.
public partial class InventoryManagementView : ContentPage, INotifyPropertyChanged
{
	public InventoryManagementView()
	{
		InitializeComponent();
		BindingContext = new InventoryManagementViewModel();
	}
	
	//BINDING MVVM: DELETE FUNCTION IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
	//BINDING MVVM: GO TO VIEW MODEL AND CREATE A DELETE FUNCTION.
	private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.Delete();
    } 

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	} 

	private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Product");
    }

	//EDIT: EDIT FUNCTION BASED ON PRODUCT ID.
	//EDIT: ROUTE MAPPED IN APP SHELL XAML SCRIPT. FUNCTION IMPLEMENTATION IN INVENTORY MANAGEMENT XAML LOGIC EditClicked(). PRODUCT DETAIL XAML LOGIC QueryProperty, ProductId { get; set; }; 
	private void EditClicked(object sender, EventArgs e)  
    {
		var productId = (BindingContext as InventoryManagementViewModel)?.SelectedProduct?.ID;
        Shell.Current.GoToAsync("//Product?productId={productId}");  
    }

	//SEARCH: SEARCH FUNCTION BASED ON QUERY 
	//SEARCH: ENTRY TEXT IN INVENTORY MANAGEMENT XAML SCRIPT. FUNCTION IMPLEMENTATION IN INVENTORY MANAGEMENT XAML LOGIC SearchClicked(). INVENTORY MANAGEMENT VIEWMODEL Query { get; set; }, ObservableCollection.
	private void SearchClicked(object sender, EventArgs e)
	{
		(BindingContext as InventoryManagementViewModel)?.RefreshProductList();
	}

	//ADD: REFRESH FUNCTION PER NAVIGATION. 
	//ADD: EVENT HANDLER IN XAML SCRIPT NavigatedTo. FUNCTION IMPLEMENTATION IN XAML LOGIC ContentPage_NavigatedTo. VIEWMODEL NotifyPropertyChanged RefreshProductList.
	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{ 
		(BindingContext as InventoryManagementViewModel)?.RefreshProductList();
	}
}