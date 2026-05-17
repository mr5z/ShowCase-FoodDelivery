using System.Collections.ObjectModel;
using FoodDelivery.Models;
using FoodDelivery.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public class OrdersViewModel(IOrderHistoryService orderHistoryService) : PageViewModel
{
    private readonly IOrderHistoryService _orderHistoryService = orderHistoryService;

    public ObservableCollection<Order> Orders { get; set; } = [];

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        LoadOrders();
    }

    private void LoadOrders()
    {
        Orders.Clear();
        foreach (var order in _orderHistoryService.GetOrders())
        {
            Orders.Add(order);
        }
    }
}