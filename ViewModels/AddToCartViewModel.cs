using System.Diagnostics;
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

    // Showcases: PopupViewModel lifecycle
    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        UpdateTotalPrice();
        Debug.WriteLine($"🛒 Add to cart popup opened for: {Item.Name}");
    }

    private void OnQuantityChanged(int value)
    {
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

        // Showcases: Closing popup with result = true (item was added)
        await Dismiss(true);
    }

    [RelayCommand]
    private async Task Cancel()
    {
        // Showcases: Closing popup with result = false (cancelled)
        await Dismiss(false);
    }
}
