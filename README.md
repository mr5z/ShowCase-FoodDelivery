# 🍔 Food Delivery App - MvvmEssentials Showcase

A fully-featured food delivery application built with .NET MAUI to demonstrate the capabilities of the [MvvmEssentials](https://github.com/mr5z/MvvmEssentials) library.

[![NuGet](https://img.shields.io/nuget/v/Nkraft.MvvmEssentials.svg)](https://www.nuget.org/packages/Nkraft.MvvmEssentials/)
[![License](https://img.shields.io/github/license/mr5z/ShowCase-FoodDelivery)](LICENSE)

## 🎯 Purpose

This project showcases real-world usage of **MvvmEssentials** - a lightweight MVVM utility library for .NET MAUI that simplifies navigation, lifecycle management, and app architecture without the overhead of Shell.

## ✨ Features Demonstrated

### MvvmEssentials Features
- ✅ **FlyoutPage Navigation** - Hamburger menu with detail page management
- ✅ **TabbedPage Support** - Bottom tab navigation with lifecycle propagation
- ✅ **Page Lifecycle Hooks** - `OnInitialized`, `OnNavigatedTo`, `OnAppearing` events
- ✅ **Popup Service** - Modal dialogs with result handling (powered by Mopups)
- ✅ **Navigation Service** - Type-safe navigation with parameter passing
- ✅ **Dependency Injection** - Full DI support with automatic page/ViewModel registration
- ✅ **MVVM Pattern** - Clean separation of concerns with ViewModels

### App Features
- 🍽️ Browse restaurants with ratings and delivery info
- 📋 View detailed restaurant menus with categories
- 🛒 Shopping cart with quantity management
- 💳 Checkout flow with address and payment selection
- 📦 Order history tracking
- 👤 User profile management
- 🔍 Search across all menu items
- ⚙️ Settings with preferences
- 🎨 Modern UI with smooth animations

## 📱 Screenshots

<table>
  <tr>
    <td><img width="250" alt="restaurants" src="https://github.com/user-attachments/assets/f2faf36f-f561-4878-a37b-384007d9ddc1" /></td>
    <td><img width="250" alt="restaurant-detail" src="https://github.com/user-attachments/assets/fbb66be6-9597-4b8a-a285-ebeafafba610" /></td>
    <td><img width="250" alt="add-to-cart-popup" src="https://github.com/user-attachments/assets/3b3eca9a-a96d-48b1-b51a-fa18d9b99a41" /></td>
  </tr>
  <tr>
    <td align="center"><b>Restaurant List</b></td>
    <td align="center"><b>Menu Items</b></td>
    <td align="center"><b>Add to Cart Popup</b></td>
  </tr>
  <tr>
    <td><img width="250" alt="cart" src="https://github.com/user-attachments/assets/91abdb85-7c96-421a-b3ef-ecf5d9563273" />
</td>
    <td><img width="250" alt="checkout" src="https://github.com/user-attachments/assets/62dffdbc-5406-494a-a451-01e030cd7de3" />
</td>
    <td><img width="250" alt="orders" src="https://github.com/user-attachments/assets/c1e34f05-6599-46b4-b289-c8b64f6354a6" />
</td>
  </tr>
  <tr>
    <td align="center"><b>Shopping Cart</b></td>
    <td align="center"><b>Checkout</b></td>
    <td align="center"><b>Order History</b></td>
  </tr>
  <tr>
    <td><img width="250" alt="menu" src="https://github.com/user-attachments/assets/a7a200e8-0bf2-4c1c-85f1-4906f60fc40b" />
</td>
    <td><img width="250" alt="settings" src="https://github.com/user-attachments/assets/47893cf5-355d-4cb1-b7a9-244517d1e60e" />
</td>
    <td><img width="250" alt="search" src="https://github.com/user-attachments/assets/cc790d02-0f56-4816-b65d-240181a9e505" />
</td>
  </tr>
  <tr>
    <td align="center"><b>Flyout Menu</b></td>
    <td align="center"><b>Settings</b></td>
    <td align="center"><b>Search</b></td>
  </tr>
</table>

## 🏗️ Architecture

```
FoodDeliveryApp/
├── ViewModels/          # All ViewModels with lifecycle hooks
├── Pages/               # XAML pages with bindings
├── Services/            # Business logic (Cart, Restaurant, OrderHistory)
├── Models/              # Data models
└── MauiProgram.cs       # DI configuration with MvvmEssentials
```

### Key Architectural Patterns

**FlyoutPage Structure:**
```
MainHostPage (FlyoutPage)
├── Menu (Flyout)
│   └── MenuViewModel
└── Detail (NavigationPage wrapper)
    └── MainTabbedPage (TabbedPage)
        ├── RestaurantsTab (NavigationPage)
        ├── SearchTab (NavigationPage)
        └── CartTab (NavigationPage)
```

**Lifecycle Propagation:**
The app demonstrates how MvvmEssentials handles the MAUI limitation where FlyoutPage detail pages don't receive lifecycle events. The library automatically propagates these events through behaviors.

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 or JetBrains Rider
- Android SDK (for Android development)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/mr5z/ShowCase-FoodDelivery.git
cd ShowCase-FoodDelivery
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the app:
```bash
# Android only for now
dotnet build -t:Run -f net9.0-android
```

## 📦 Using MvvmEssentials in Your Project

This app shows how to set up MvvmEssentials. Here's a quick start:

### 1. Install the package
```bash
dotnet add package Nkraft.MvvmEssentials
```

### 2. Configure in MauiProgram.cs
```csharp
builder
    .UseMauiApp<App>()
    .ConfigureMvvmEssentials(Assembly.GetExecutingAssembly(), registry =>
    {
        registry.MapPage<MainHostPage, MainHostViewModel>(isInitial: true)
            .MapPage<OrdersPage, OrdersViewModel>()
            .MapPage<ProfilePage, ProfileViewModel>()
            .MapPage<RestaurantDetailPage, RestaurantDetailViewModel>();
    })
    .ConfigureMopups(); // For popup support

builder.Services.AddDiscoveredAppStartup();
```

### 3. Use in ViewModels
```csharp
public partial class RestaurantsTabViewModel(INavigationService navigationService) : TabViewModel
{
    [RelayCommand]
    private async Task OpenRestaurant(Restaurant restaurant)
    {
        var parameters = new NavigationParameters { { "RestaurantId", restaurant.Id } };
        await navigationService.NavigateAsync<RestaurantDetailViewModel>(parameters);
    }
}
```

## 🔧 Key Implementation Details

### FlyoutPage with TabbedPage Detail
The app demonstrates the complex scenario of a FlyoutPage containing a TabbedPage as its detail, with proper lifecycle event propagation through the `FlyoutDetailLifecycleBehavior`.

### Original Detail Caching
To work around MAUI's FlyoutPage bug, the NavigationService caches the original Detail page (MainTabbedPage) and restores it when navigating back to Home, preserving tab state and preventing unnecessary recreations.

### Cart Service
Singleton service managing cart state across the app with automatic UI updates through `ObservableCollection<CartItem>`. Cart items recalculate totals automatically via Fody.PropertyChanged.

### Popup with Results
Shows how to present modal dialogs and handle user input:
```csharp
var navParams = new NavigationParameters 
{ 
    { nameof(AddToCartViewModel.Item), menuItem } 
};

var result = await _popupService.PresentAsync<AddToCartViewModel, CartItem>(navParams);
if (result.TryGetValue(out var cartItem))
{
    _cartService.AddItem(cartItem);
}
```

### Handler Pattern for Navigation
The NavigationService uses a strategy pattern with dedicated handlers for each page type:
- `NavigationPageHandler` - Push navigation
- `TabbedPageHandler` - Tab-aware navigation  
- `FlyoutPageHandler` - Detail management with caching
- `UnsupportedPageHandler` - Fallback error handling

### Property Change Weaving
Uses Fody.PropertyChanged (`[AddINotifyPropertyChangedInterface]`) for automatic INotifyPropertyChanged implementation, resulting in cleaner ViewModels without boilerplate.

## 🤝 Contributing

This is a showcase project, but contributions to improve the examples or fix issues are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/improvement`)
3. Commit your changes (`git commit -am 'Add some improvement'`)
4. Push to the branch (`git push origin feature/improvement`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built with [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
- Navigation powered by [MvvmEssentials](https://github.com/mr5z/MvvmEssentials)
- Popups powered by [Mopups](https://github.com/LuckyDucko/Mopups)
- MVVM tooling by [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet)
- Property change weaving by [Fody.PropertyChanged](https://github.com/Fody/PropertyChanged)

## 📚 Learn More

- [MvvmEssentials Documentation](https://github.com/mr5z/MvvmEssentials#readme)
- [.NET MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [MVVM Pattern](https://learn.microsoft.com/dotnet/architecture/maui/mvvm)

---

**Note:** This is a demonstration app with mock data. It's not intended for
production use but as a learning resource for MvvmEssentials.
