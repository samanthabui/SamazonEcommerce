# Samazon - eCommerce Application

## Overview

Samazon is an eCommerce application developed using **C#** and **.NET**. The application aims to provide an inventory management system, a shopping cart functionality, and a checkout system, including tax calculations. Currently, the project is implemented as a **console application** but will be incrementally transitioned to a **user interface (UI)** application using the **MVVM architecture**.

### Key Features:
- **Inventory Management**:
  - CRUD (Create, Read, Update, Delete) functionality for managing inventory items.
  - View and modify inventory items such as product name, price, and quantity.
  
- **Shopping Cart**:
  - CRUD functionality to add, read, update, and delete items in the shopping cart.
  - Users can add products to the cart, adjust quantities, and remove items.

- **Checkout System**:
  - Includes tax calculations for checkout based on the current inventory and user selections.

### Architecture:
- **Object-Oriented Design (OOD)**: The system utilizes object-oriented principles to design a maintainable and scalable codebase.
- **Singleton Pattern**: The product services are implemented using the Singleton pattern to ensure a single instance of product-related operations across the application.

### Planned Features:
- Transition from a console application to a full-fledged **UI application** using **MVVM (Model-View-ViewModel)** architecture for improved user interaction and design.

## Directory Structure

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
