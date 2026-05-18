using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Extensions;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.Services.Navigation;
using Nkraft.MvvmEssentials.ViewModels;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

public partial class RestaurantDetailViewModel(
    INavigationService navigationService,
    IPopupService popupService,
    IRestaurantService restaurantService)
    : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IPopupService _popupService = popupService;
    private readonly IRestaurantService _restaurantService = restaurantService;

    public int RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public ObservableCollection<MenuItem> MenuItems { get; } = [];

    protected override void OnInitialized()
    {
        base.OnInitialized();
        LoadRestaurant();
    }

    private void LoadRestaurant()
    {
        Restaurant = _restaurantService.GetRestaurantById(RestaurantId);
        if (Restaurant != null)
        {
            MenuItems.Clear();
            foreach (var item in Restaurant.MenuItems)
            {
                MenuItems.Add(item);
            }
        }
    }

    [RelayCommand]
    private async Task SelectMenuItem(MenuItem item)
    {
        var parameters = new NavigationParameters
        {
            { "RestaurantId", RestaurantId },
            { "Item", item }
        };
        var result = await _popupService.PresentAsync<AddToCartViewModel, bool>(parameters);

        if (result is { IsSuccess: true, Value: true })
        {
            Debug.WriteLine($"✅ Item added to cart: {item.Name}");
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}
