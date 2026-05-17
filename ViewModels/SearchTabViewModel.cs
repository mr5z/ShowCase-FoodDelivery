using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

/// <summary>
/// Search tab - showcases TabViewModel with search functionality
/// </summary>
public partial class SearchTabViewModel(
    INavigationService navigationService,
    IRestaurantService restaurantService)
    : TabViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IRestaurantService _restaurantService = restaurantService;

    public string? SearchText { get; set; }

    public ObservableCollection<MenuItem> SearchResults { get; } = [];
    public string TabTitle => "Search";
    public string TabIcon => "🔍";

    protected override void OnTabSelected()
    {
        base.OnTabSelected();
        System.Diagnostics.Debug.WriteLine("🔍 Search tab selected!");
    }

    [RelayCommand]
    private void PerformSearch()
    {
        SearchResults.Clear();

        if (string.IsNullOrWhiteSpace(SearchText))
            return;

        var allItems = _restaurantService.GetAllRestaurants()
            .SelectMany(r => r.MenuItems)
            .Where(item => item.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                          item.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var item in allItems)
        {
            SearchResults.Add(item);
        }
    }

    [RelayCommand]
    private async Task SelectItem(MenuItem item)
    {
        // Showcases: Opening popup from tab
        var restaurant = _restaurantService.GetAllRestaurants()
            .First(r => r.MenuItems.Any(mi => mi.Id == item.Id));
        
        await _navigationService.NavigateAsync<ItemDetailViewModel, object>(new
        {
            ItemId = item.Id,
            RestaurantId = restaurant.Id
        });
    }
}
