using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;
using Nkraft.MvvmEssentials.Services.Navigation;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

/// <summary>
/// Restaurant detail - showcases PageViewModel lifecycle and parameter receiving
/// </summary>
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

    // Showcases: PageViewModel lifecycle - called once on first appearance
    protected override void OnInitialized()
    {
        base.OnInitialized();
        LoadRestaurant();
        System.Diagnostics.Debug.WriteLine($"🏪 Restaurant detail initialized for ID: {RestaurantId}");
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
        // Showcases: Opening popup and getting result
        var parameters = new NavigationParameters
        {
            { "RestaurantId", RestaurantId },
            { "Item", item }
        };
        var result = await _popupService.PresentAsync<AddToCartViewModel, bool>(parameters);

        if (result is { IsSuccess: true, Value: true })
        {
            System.Diagnostics.Debug.WriteLine($"✅ Item added to cart: {item.Name}");
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}
