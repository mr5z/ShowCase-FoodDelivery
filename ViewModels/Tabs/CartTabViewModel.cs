using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Extensions;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.Services.Navigation;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels.Tabs;

public partial class CartTabViewModel : TabViewModel
{
    private readonly INavigationService _navigationService;
    private readonly ICartService _cartService;
    private readonly IPopupService _popupService;

    public decimal Subtotal { get; set; }

    public int TotalItems { get; set; }

    public ObservableCollection<CartItem> CartItems { get; } = [];
    public string TabTitle => "Cart";
    public string TabIcon => "🛒";

    public CartTabViewModel(
        INavigationService navigationService,
        ICartService cartService,
        IPopupService popupService)
    {
        _navigationService = navigationService;
        _cartService = cartService;
        _popupService = popupService;

        // Listen to cart changes from other parts of the app
        _cartService.CartUpdated += OnCartUpdated;
    }

    protected override void OnTabSelected()
    {
        base.OnTabSelected();
        RefreshCart();
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
    private async Task DecreaseQuantity(CartItem cartItem)
    {
        var willBeRemoved = cartItem.Quantity - 1 <= 0;
        if (willBeRemoved)
        {
            var parameters = new NavigationParameters { { "Item", cartItem.Item } };
            var result = await _popupService.PresentAsync<ConfirmRemoveItemViewModel, bool>(parameters);
            if (result.TryGetValue(out var confirmed) && confirmed)
            {
                _cartService.UpdateQuantity(cartItem.Item, cartItem.Quantity - 1);
            }
        }
        else
        {
            _cartService.UpdateQuantity(cartItem.Item, cartItem.Quantity - 1);
        }
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

        await _navigationService.NavigateAsync<CheckoutViewModel>();
    }

    protected override void OnDispose()
    {
        _cartService.CartUpdated -= OnCartUpdated;
        base.OnDispose();
    }
}
