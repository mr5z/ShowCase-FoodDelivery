using PropertyChanged;

namespace FoodDelivery.Models;

[AddINotifyPropertyChangedInterface]
public sealed class Restaurant
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Cuisine { get; init; }
    public double Rating { get; set; }
    public required string DeliveryTime { get; init; }
    public required string ImageEmoji { get; init; }
    public decimal MinOrder { get; set; }
    public decimal DeliveryFee { get; set; }
    public List<MenuItem> MenuItems { get; init; } = [];
}

[AddINotifyPropertyChangedInterface]
public sealed class MenuItem
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public decimal Price { get; set; }
    public required string ImageEmoji { get; init; }
    public required string Category { get; init; }
    public bool IsPopular { get; set; }
}

[AddINotifyPropertyChangedInterface]
public sealed class CartItem
{
    public required MenuItem Item { get; init; }
    public int Quantity { get; set; }
    public decimal Total => Item.Price * Quantity;
}

[AddINotifyPropertyChangedInterface]
public class Order
{
    public string? OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "Pending";
    public int ItemsCount { get; set; }
    public decimal Total { get; set; }
    public required string DeliveryAddress { get; set; }
    public required string PaymentMethod { get; set; }
    public required string DeliveryInstructions { get; set; }
}