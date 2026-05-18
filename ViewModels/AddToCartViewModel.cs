using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

public partial class AddToCartViewModel(IPopupService popupService, ICartService cartService)
    : PopupViewModel<bool>(popupService)
{
    private readonly ICartService _cartService = cartService;

    public MenuItem Item { get; set; } = null!;

    public int RestaurantId { get; set; }

    public int Quantity { get; set; } = 1;

    public decimal TotalPrice { get; set; }

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        UpdateTotalPrice();
    }

    private void UpdateTotalPrice()
    {
        TotalPrice = Item.Price * Quantity;
    }

    [RelayCommand]
    private void IncreaseQuantity()
    {
        if (Quantity < 99)
        {
            Quantity++;
            UpdateTotalPrice();            
        }
    }

    [RelayCommand]
    private void DecreaseQuantity()
    {
        if (Quantity > 1)
        {
            Quantity--;
            UpdateTotalPrice();            
        }
    }

    [RelayCommand]
    private async Task AddToCart()
    {
        // Add item to cart
        for (var i = 0; i < Quantity; i++)
        {
            _cartService.AddItem(Item);
        }

        await Dismiss(true);
    }

    [RelayCommand]
    private async Task Cancel()
    {
        await Dismiss(false);
    }
}
