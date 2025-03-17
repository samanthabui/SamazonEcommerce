//MAUI: CONTENT PAGE PRODUCT DETAILS XAML LOGIC
using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;
using Samazon.Models;

namespace Maui.eCommerce.Views;

[QueryProperty(nameof(ProductId), "productId")]

//BINDING MVVM: PRODUCTVIEWMODEL IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
//BINDING MVVM: GO TO VIEW MODEL AND CREATE A PRODUCTVIEWMODEL FUNCTION.
public partial class ProductDetails : ContentPage
{
	public ProductDetails()
	{
		InitializeComponent();
		//BindingContext = new ProductViewModel();
	} 

	//EDIT: EDIT FUNCTION BASED ON PRODUCT ID.
	//EDIT: ROUTE MAPPED IN APP SHELL XAML SCRIPT. FUNCTION IMPLEMENTATION IN INVENTORY MANAGEMENT XAML LOGIC EditClicked(). PRODUCT DETAIL XAML LOGIC QueryProperty, ProductId { get; set; }; 
	public int ProductId { get; set; }
	private void GoBackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//InventoryManagement");
	}

	private void SubmitClicked(object sender, EventArgs e)
	{
		var name = (BindingContext as ProductViewModel).Name;
		ProductServiceProxy.Current.AddOrUpdate(new Product {Name = name});
		Shell.Current.GoToAsync("//InventoryManagement");
	}

	//ADD: REFRESH FUNCTION PER NAVIGATION. 
	//ADD: EVENT HANDLER IN XAML SCRIPT NavigatedTo. FUNCTION IMPLEMENTATION IN XAML LOGIC ContentPage_NavigatedTo. VIEWMODEL NotifyPropertyChanged RefreshProductList.
	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{ 
		if(ProductId == 0)
		{
			BindingContext = new ProductViewModel();
		}
		else
		{
			BindingContext = new ProductViewModel(ProductServiceProxy.Current.GetById(ProductId));
		}
	}
}
