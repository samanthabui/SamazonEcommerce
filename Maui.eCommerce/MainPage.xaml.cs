//CONTENT PAGE MAIN PAGE XAML LOGIC
namespace Maui.eCommerce;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		//BindingContext = this; MEANS THIS VIEW IS ITS OWN BINDING. VIEW AND VIEW MODEL SAME.
	}

	//HAVE A PROPERTY THAT IS ACCESSIBLE TO BIND TO FRONT END. BINDING SYNTAX TO GET TO BINDING CONTEXT OF VIEW.
	public string Display{
		get
		{
			return "Hello, World!";
		}
	}

	private void InventoryClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//InventoryManagement");
	}

}

