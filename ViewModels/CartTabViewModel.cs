using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;

namespace FoodDelivery.ViewModels;

/// <summary>
/// Cart tab - showcases TabViewModel with service integration
/// Updates when items are added from other tabs
/// </summary>
public partial class CartTabViewModel : TabViewModel
{
    private readonly INavigationService _navigationService;
    private readonly ICartService _cartService;

    public decimal Subtotal { get; set; }

    public int TotalItems { get; set; }

    public ObservableCollection<CartItem> CartItems { get; } = [];
    public string TabTitle => "Cart";
    public string TabIcon => "🛒";

    public CartTabViewModel(
        INavigationService navigationService,
        ICartService cartService)
    {
        _navigationService = navigationService;
        _cartService = cartService;

        // Listen to cart changes from other parts of the app
        _cartService.CartUpdated += OnCartUpdated;
    }

    protected override void OnTabSelected()
    {
        base.OnTabSelected();
        RefreshCart();
        System.Diagnostics.Debug.WriteLine("🛒 Cart tab selected!");
    }

    private void OnCartUpdated(object? sender, EventArgs e)
    {
        RefreshCart();
    }

    private void RefreshCart()
    {
        CartItems.Clear();
        foreach (var item in _cartService.GetCartItems())
        {
            CartItems.Add(item);
        }

        Subtotal = _cartService.GetSubtotal();
        TotalItems = _cartService.GetTotalItems();
    }

    [RelayCommand]
    private void IncreaseQuantity(CartItem cartItem)
    {
        _cartService.UpdateQuantity(cartItem.Item, cartItem.Quantity + 1);
    }

    [RelayCommand]
    private void DecreaseQuantity(CartItem cartItem)
    {
        _cartService.UpdateQuantity(cartItem.Item, cartItem.Quantity - 1);
    }

    [RelayCommand]
    private void RemoveItem(CartItem cartItem)
    {
        _cartService.RemoveItem(cartItem.Item);
    }

    [RelayCommand]
    private async Task Checkout()
    {
        if (CartItems.Count == 0)
            return;

        // Showcases: Navigation to checkout
        await _navigationService.NavigateAsync<CheckoutViewModel>();
    }

    protected override void OnDispose()
    {
        _cartService.CartUpdated -= OnCartUpdated;
        base.OnDispose();
    }
}
