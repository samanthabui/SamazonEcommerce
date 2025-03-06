//CONTENT PAGE INVENTORY MANAGEMENT XAML LOGIC
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

//PARTIAL MAKES SURE PART OF CLASS DEF IN XAML AND PART DEF IN C#
//INHERITANCE MEANS AN OBJ KEEPS ALL OF PARENTS.
public partial class InventoryManagementView : ContentPage
{
	public InventoryManagementView()
	{
		InitializeComponent();
		BindingContext = new InventoryManagementViewModel();
	}
    
	//SELECTED PROD IS SET TO ID OF A PROD. SEND IT INTO SERVICE PROXY DELETE METHOD.
	//INSTEAD OF CASTING, COHERSION ATTEMPTS TO CAST AND DOES NOT CRASH.

	//GO FROM CODE BEHIND TO VIEW MODEL. VIEW MODEL IS BINDING CONTEXT WHICH IS OBJ. 
	//BUT IN ORDER TO MAKE APP, CONCRETE TYPE. TYPE COERSION ALLOWS YOU TO GO TO CONCRETE TYPE.

	//DELETE FUNCTION IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
	//GO TO VIEW MODEL AND CREATE A DELETE FUNCTION.

	private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.Delete();
    }

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	} 
}

