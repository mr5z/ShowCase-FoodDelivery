using System.Reflection;
using CommunityToolkit.Maui;
using FoodDelivery.Pages;
using FoodDelivery.Pages.Menus;
using FoodDelivery.Services;
using FoodDelivery.ViewModels;
using FoodDelivery.ViewModels.Menus;
using FoodDelivery.ViewModels.Tabs;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Nkraft.MvvmEssentials;
using Nkraft.MvvmEssentials.Extensions;

namespace FoodDelivery;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureMvvmEssentials(Assembly.GetExecutingAssembly(), registry =>
            {
                // Main FlyoutPage setup - showcases FlyoutHostViewModel
                registry
                    .MapPage<MainHostPage, MainHostViewModel>(isInitial: true)
                        .RegisterPage<MenuViewModel>()
                        .RegisterPage<MainTabbedViewModel>()
                            .RegisterPage<RestaurantsTabViewModel>()
                            .RegisterPage<SearchTabViewModel>()
                            .RegisterPage<CartTabViewModel>();
 
                // Regular pages - showcases PageViewModel
                registry.MapPage<RestaurantDetailPage, RestaurantDetailViewModel>()
                    .MapPage<ItemDetailPage, ItemDetailViewModel>()
                    .MapPage<OrdersPage, OrdersViewModel>()
                    .MapPage<ProfilePage, ProfileViewModel>()
                    .MapPage<SettingsPage, SettingsViewModel>()
                    .MapPage<CheckoutPage, CheckoutViewModel>();
 
                // Popup - showcases PopupViewModel
                registry.MapPage<AddToCartPopup, AddToCartViewModel>();
                registry.MapPage<ConfirmRemoveItemPopup, ConfirmRemoveItemViewModel>();
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddDiscoveredAppStartup();
        builder.Services.AddSingleton<IRestaurantService, RestaurantService>();
        builder.Services.AddSingleton<ICartService, CartService>();
        builder.Services.AddSingleton<IOrderHistoryService, OrderHistoryService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    // internal sealed class GeneratedAppStartup(INavigationService navigationService) : IAppStartup
    // {
    //     private readonly INavigationService _navigationService = navigationService;
    //
    //     public async Task OnInitializedAsync()
    //     {
    //         await _navigationService
    //             .Absolute(withNavigation: false)
    //             .Push<MainHostViewModel>()
    //             .NavigateAsync();
    //     }
    // }
}