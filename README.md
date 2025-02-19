# Samazon eCommerce Application

## DESCRIPTION:

Samazon is an eCommerce application developed using **C#** and **.NET**. The application aims to provide an inventory management system, a shopping cart functionality, and a checkout system, including tax calculations. Currently, the project is implemented as a **console application** but will be incrementally transitioned to a **user interface (UI)** application using the **MVVM architecture**.

### FUNCTIONALITY:
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
Samazon
│
├── Program.cs
├── Samazon.csproj

Library.eCommerce
│
├── Library.eCommerce.csproj
├── Models
│   └── Product.cs
└── Services
    └── ProductServiceProxy.cs

Maui.eCommerce
│
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── Maui.eCommerce.csproj
├── MauiProgram.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── Properties
├── Resources
├── Platforms
