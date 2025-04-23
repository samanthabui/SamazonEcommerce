//MAUI: CONTENT PAGE CART MANAGEMENT LOGIC
using Maui.eCommerce.ViewModels;
namespace Maui.eCommerce.Views;

//CART MANAGEMENT
public partial class ShoppingManagementView: ContentPage
{
	public ShoppingManagementView()
	{
		InitializeComponent();
		BindingContext = new ShoppingManagementViewModel();
	}

    //CART MANAGEMENT: PURCHASE
	private void AddToCartClicked(object sender, EventArgs e)
	{
		(BindingContext as ShoppingManagementViewModel).PurchaseItem();
	}

    //CART MANAGEMENT: PURCHASE RETURN
	private void RemoveFromCartClicked(object sender, EventArgs e)
	{
		(BindingContext as ShoppingManagementViewModel).ReturnItem();
	}

	//CART MANAGEMENT: IN LINE BUTTON USING ICOMMAND.
	private void InLineAddClicked(object sender, EventArgs e)
	{
		(BindingContext as ShoppingManagementViewModel).RefreshUX();
	}
	
}
