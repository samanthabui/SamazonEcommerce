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
	//BINDING MVVM: PRODUCTVIEWMODEL IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
	//BINDING MVVM: GO TO VIEW MODEL AND CREATE A PRODUCTVIEWMODEL FUNCTION.
	public class ProductViewModel
	{
		public string? Name { get; set; }
	}
}
