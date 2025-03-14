//MAUI: CONTENT PAGE PRODUCT DETAILS XAML LOGIC
using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;
using Samazon.Models;

namespace Maui.eCommerce.Views;

//BINDING MVVM: PRODUCTVIEWMODEL IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
//BINDING MVVM: GO TO VIEW MODEL AND CREATE A PRODUCTVIEWMODEL FUNCTION.
public partial class ProductDetails : ContentPage
{
	public ProductDetails()
	{
		InitializeComponent();
		BindingContext = new ProductViewModel();
	}

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
}
