using CommunityToolkit.Mvvm.Input;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class CheckoutViewModel(
    INavigationService navigationService,
    IModalService modalService,
    ICartService cartService,
    IOrderHistoryService orderHistoryService)
    : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IModalService _modalService = modalService;
    private readonly ICartService _cartService = cartService;
    private readonly IOrderHistoryService _orderHistoryService = orderHistoryService;

    public DeliveryAddress Address { get; set; } = new("123 Main St", "Apt 4B", "San Francisco", "94102");
    public string AddressSummary => Address.ToString();
    public string SelectedPaymentMethod { get; set; } = "CreditCard";
    public string DeliveryInstructions { get; set; } = string.Empty;

    public decimal Subtotal => _cartService.GetSubtotal();
    public decimal DeliveryFee => 2.99m;
    public decimal Total => Subtotal + DeliveryFee;

    [RelayCommand]
    private async Task PlaceOrder()
    {
        // Create order from cart
        var order = new Order
        {
            ItemsCount = _cartService.GetTotalItems(),
            Total = Total,
            DeliveryAddress = Address.ToString(),
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
    private async Task EditAddress()
    {
        var destination = EditAddressViewModel.With(
            street: Address.Street,
            apartment: Address.Apartment,
            city: Address.City,
            zipCode: Address.ZipCode);

        var result = await _modalService.PresentAsync(destination);
        if (result.TryGetValue(out var address))
        {
            Address = address;
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}