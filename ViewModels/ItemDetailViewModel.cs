using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials;
using Nkraft.MvvmEssentials.Attributes;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class ItemDetailViewModel(INavigationService navigationService) : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [NavigationParameter]
    public int ItemId { get; set; }

    [NavigationParameter]
    public int RestaurantId { get; set; }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateAsync(With(itemId: 0, restaurantId: 0));
        await _navigationService.NavigateBackAsync();
    }
}
