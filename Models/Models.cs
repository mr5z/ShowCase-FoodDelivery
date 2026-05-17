using PropertyChanged;

namespace FoodDelivery.Models;

[AddINotifyPropertyChangedInterface]
public sealed class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cuisine { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string DeliveryTime { get; set; } = string.Empty;
    public string ImageEmoji { get; set; } = string.Empty;
    public decimal MinOrder { get; set; }
    public decimal DeliveryFee { get; set; }
    public List<MenuItem> MenuItems { get; set; } = [];
}

[AddINotifyPropertyChangedInterface]
public sealed class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageEmoji { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
}

[AddINotifyPropertyChangedInterface]
public sealed class CartItem
{
    public MenuItem Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Total => Item.Price * Quantity;
}

[AddINotifyPropertyChangedInterface]
public class Order
{
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ItemsCount { get; set; }
    public decimal Total { get; set; }
    public string DeliveryAddress { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public string DeliveryInstructions { get; set; } = string.Empty;
}