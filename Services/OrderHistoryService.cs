using FoodDelivery.Models;

namespace FoodDelivery.Services;

public interface IOrderHistoryService
{
    IReadOnlyList<Order> GetOrders();
    void AddOrder(Order order);
    void ClearHistory();
}

public class OrderHistoryService : IOrderHistoryService
{
    private readonly List<Order> _orders = new();
    private int _nextOrderNumber = 1001;

    public IReadOnlyList<Order> GetOrders() => _orders.AsReadOnly();

    public void AddOrder(Order order)
    {
        order.OrderNumber = _nextOrderNumber.ToString();
        order.OrderDate = DateTime.Now;
        order.Status = "Confirmed";
        
        _orders.Insert(0, order); // Add to beginning (most recent first)
        _nextOrderNumber++;
    }

    public void ClearHistory()
    {
        _orders.Clear();
    }
}