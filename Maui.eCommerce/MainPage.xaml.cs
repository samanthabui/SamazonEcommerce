//MAUI: CONTENT PAGE MAIN PAGE XAML LOGIC
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		//BindingContext = this; //ASSIGNS BINDING CONTEXT TO VIEW. VIEWMODEL AND VIEW ARE SAME, VIOLATING MVVM. 
		BindingContext = new MainViewModel(); //ASSIGNS BINDING CONTEXT TO VIEWMODEL, ADHERING TO MVVM.
	}

/* 
	//BINDING MVVM: VIOLATES MVVM IF VIEW AND VIEW MODEL ARE THE SAME. THEREFORE, MAKE CLASS NAMED MAINVIEWMODEL.
	//BINDING MVVM: DECOUPLE THE DEPENDENCIES. HAVE THE ABILITY TO REUSE VIEWMODELS.
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    //BINDING MVVM: TO BIND TO FRONT END, HAVE A PROPERTY THAT IS ACCESSIBLE. YOU CAN'T BIND SOMETHING NOT A PROPERTY. 
    //BINDING MVVM: XAML SCRIPT "{BINDING DISPLAY}" SAYS GO TO BINDING CONTEXT OF THIS VIEW, FIND A PROPERTY NAMED DISPLAY.
	public string Display{
		get
		{
			return "HOME";
		}
	}
*/

	private void InventoryClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//InventoryManagement");
	}
}

