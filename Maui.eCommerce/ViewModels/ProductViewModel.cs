//MAUI: CONTENT PAGE PRODUCT VIEW MODEL
using Library.eCommerce.Models;
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
	//BINDING MVVM: GO  TO VIEW MODEL AND CREATE A PRODUCTVIEWMODEL FUNCTION.
	public class ProductViewModel
	{
		//CACHED MODEL SAVES COPY AT INITIATION OF THE MODEL
		private Item? cachedModel { get; set; }

		//EDIT: TYPE OF PROPERTIES - PROPERTY THAT TAKES DATA FROM CLASS, PROPERTY PUBLIC ACCESSORS TO PIECE OF INFORMATION.
		public string? Name 
		{ 
			get 
			{
				return Model?.Product?.Name ?? string.Empty;
			}
			set 
			{
				if(Model != null && Model.Product?.Name != value)
				{
					Model.Product.Name = value;
				}
			}
		} 

		//EDIT: INT? NULLABLE IS A FEATURE. NOT A BUG. SO IMLPEMENT ? NULLABLE TO INT QUANTITY INSTEAD.
		public int? Quantity
		{
			get
			{
				return Model?.Quantity;
			}
			set
			{
				if(Model != null && Model.Quantity != value)
				{
					Model.Quantity = value;
				}
			}
		}
 
		public Item? Model { get; set; }

		//BINDING MVVM: PRODUCTVIEWMODEL IS TIGHTLY COUPLED TO VIEW. WANT TO ENCAPSULATE FOR THE VIEW MODEL TO HANDLE PRODUCT SERVICE PROXY.
		//BINDING MVVM: GO TO VIEW MODEL AND CREATE A PRODUCTVIEWMODEL FUNCTION.
		public void AddOrUpdate()
		{
			ProductServiceProxy.Current.AddOrUpdate(Model);
		}

		//CACHED MODEL SAVES COPY AT INITIATION OF THE MODEL
		public void Undo()
		{
			//DEEP COPY: SHALLOW COPY MODIFIED, DEEP COPY NOT MODIFIED. MODIFY DIRECTLY IN PRODUCTSERVICEPROXY.
			//Model = cachedModel; 
			ProductServiceProxy.Current.AddOrUpdate(cachedModel);
		}

		//DEFAULT CONSTRUCTOR
		public ProductViewModel()
		{
			Model = new Item();
			cachedModel = null;
		}

		//COPY CONSTRUCTOR
		//EDIT: CONVERSION CONSTRUCTOR CONVERTS FROM MODEL TO VIEWMODEL.
		public ProductViewModel(Item? model)
		{ 
			Model = model;
			//CACHED MODEL: SAVES COPY AT INITIATION OF THE MODEL
			if(model != null)
			{
			cachedModel = new Item(model);
			}
		} 
	}	
}
