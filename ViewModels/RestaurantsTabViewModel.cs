using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;

namespace FoodDelivery.ViewModels;

/// <summary>
/// Restaurants tab - showcases TabViewModel lifecycle and navigation with parameters
/// </summary>
public partial class RestaurantsTabViewModel(
    INavigationService navigationService,
    IRestaurantService restaurantService)
    : TabViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IRestaurantService _restaurantService = restaurantService;

    public ObservableCollection<Restaurant> Restaurants { get; } = [];
    public string TabTitle => "Restaurants";
    public string TabIcon => "🏪";

    // Showcases: TabViewModel lifecycle - called first time tab is selected
    protected override void OnInitialized()
    {
        base.OnInitialized();
        LoadRestaurants();
        System.Diagnostics.Debug.WriteLine("🍴 Restaurants tab initialized!");
    }

    // Showcases: TabViewModel lifecycle - called every time tab is selected
    protected override void OnTabSelected()
    {
        base.OnTabSelected();
        System.Diagnostics.Debug.WriteLine("🍴 Restaurants tab selected!");
    }

    // Showcases: TabViewModel lifecycle - called when tab is unselected
    protected override void OnTabUnselected()
    {
        base.OnTabUnselected();
        System.Diagnostics.Debug.WriteLine("🍴 Restaurants tab unselected!");
    }

    private void LoadRestaurants()
    {
        Restaurants.Clear();
        foreach (var restaurant in _restaurantService.GetAllRestaurants())
        {
            Restaurants.Add(restaurant);
        }
    }

    [RelayCommand]
    private async Task SelectRestaurant(Restaurant restaurant)
    {
        // Showcases: Navigation with parameters - passing restaurant ID to detail page
        await _navigationService.NavigateAsync<RestaurantDetailViewModel, object>(new
        {
            RestaurantId = restaurant.Id
        });
    }
}
