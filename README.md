# Samazon eCommerce Application

## DESCRIPTION:

Samazon is an eCommerce application developed using C# and .NET. The application is designed to provide inventory management with CRUD functionality, shopping cart management with CRUD functionality, and a checkout system including tax calculations. The app is built using the .NET MAUI framework, utilizing the Model-View-ViewModel (MVVM) architecture for scalability, simplicity, and performance.

## FUNCTIONALITY:
- **Inventory Management**:
  - **Create Inventory Item**: Add new products to the inventory with details such as name, price, and quantity.
  - **Read Inventory Items**: View all existing products in the inventory, including their attributes.
  - **Update Inventory Item**: Modify product details, such as adjusting the price or quantity of an item.
  - **Delete Inventory Item**: Remove products from the inventory when no longer available or needed.
  
- **Shopping Cart**:
  - **Add Item to Cart**: Add selected products from the inventory to the shopping cart.
  - **Read Items in Cart**: View all items currently in the cart, including quantities and total cost.
  - **Update Item in Cart**: Modify the quantity or other attributes of an item in the cart.
  - **Delete Item in Cart**: Remove unwanted items from the cart before checkout.

- **Checkout System**:
  - Includes tax calculations for checkout based on the current inventory and user selections.

## DIRECTORY STRUCTURE:

```plaintext
Samazon/
├── Program.cs
├── Samazon.csproj

Library.eCommerce/
├── Library.eCommerce.csproj
├── Models/
│   ├── Item.cs
│   ├── Product.cs
└── Services/
    ├── ProductServiceProxy.cs
    └── ShoppingCartService.cs

Maui.eCommerce/
├── Maui.eCommerce.csproj
├── App.xaml.cs
├── MauiProgram.cs
├── AppShell.xaml.cs
├── AppShell.xaml
├── Views/
│   ├── InventoryManagementView.xaml
│   ├── InventoryManagementView.xaml.cs
│   ├── ProductDetails.xaml
│   ├── ProductDetails.xaml.cs
│   ├── ShoppingManagementView.xaml
│   └── ShoppingManagementView.xaml.cs
├── ViewModels/
│   ├── InventoryManagementViewModel.cs
│   ├── ProductViewModel.cs
│   ├── ShoppingManagementViewModel.cs
│   └── MainViewModel.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── Properties/
├── Resources/
├── Platforms/
