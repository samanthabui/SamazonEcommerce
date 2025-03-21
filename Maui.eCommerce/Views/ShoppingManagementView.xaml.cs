//MAUI: CONTENT PAGE SHOPPING MANAGEMENT LOGIC
using Maui.eCommerce.ViewModels;
namespace Maui.eCommerce.Views;

//SERVICES  
public partial class ShoppingManagementView: ContentPage
{
	public ShoppingManagementView()
	{
		InitializeComponent();
		BindingContext = new ShoppingManagementViewModel();
	}

	private void AddToCartClicked(object sender, EventArgs e)
	{

	}
}