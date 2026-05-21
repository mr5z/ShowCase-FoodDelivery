using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels.Tabs;

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

    protected override void OnInitialized()
    {
        base.OnInitialized();
        LoadRestaurants();
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
        await _navigationService.NavigateAsync<RestaurantDetailViewModel, object>(new
        {
            RestaurantId = restaurant.Id
        });
    }
}
