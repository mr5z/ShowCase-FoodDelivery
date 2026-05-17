using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class CheckoutViewModel(
    INavigationService navigationService,
    ICartService cartService,
    IOrderHistoryService orderHistoryService)
    : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly ICartService _cartService = cartService;
    private readonly IOrderHistoryService _orderHistoryService = orderHistoryService;

    public string StreetAddress { get; set; } = "123 Main St";
    public string Apartment { get; set; } = "Apt 4B";
    public string City { get; set; } = "San Francisco";
    public string ZipCode { get; set; } = "94102";
    public string SelectedPaymentMethod { get; set; } = "CreditCard";
    public string DeliveryInstructions { get; set; } = string.Empty;

    public decimal Subtotal => _cartService.GetSubtotal();
    public decimal DeliveryFee => 2.99m;
    public decimal Total => Subtotal + DeliveryFee;

    [RelayCommand]
    private async Task PlaceOrder()
    {
        // Validate address fields
        if (string.IsNullOrWhiteSpace(StreetAddress) || 
            string.IsNullOrWhiteSpace(City) || 
            string.IsNullOrWhiteSpace(ZipCode))
        {
            return;
        }

        // Create order from cart
        var order = new Order
        {
            ItemsCount = _cartService.GetTotalItems(),
            Total = Total,
            DeliveryAddress = string.IsNullOrWhiteSpace(Apartment)
                ? $"{StreetAddress}, {City} {ZipCode}"
                : $"{StreetAddress}, {Apartment}, {City} {ZipCode}",
            PaymentMethod = SelectedPaymentMethod,
            DeliveryInstructions = DeliveryInstructions
        };

        // Save order to history
        _orderHistoryService.AddOrder(order);

        // Clear cart
        _cartService.ClearCart();

        // Navigate back to home
        await _navigationService.NavigateToRootAsync();
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}