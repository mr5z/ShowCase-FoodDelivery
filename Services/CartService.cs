using FoodDelivery.Models;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.Services;

public interface ICartService
{
    event EventHandler? CartUpdated;
    List<CartItem> GetCartItems();
    void AddItem(MenuItem item);
    void RemoveItem(MenuItem item);
    void UpdateQuantity(MenuItem item, int quantity);
    void ClearCart();
    int GetTotalItems();
    decimal GetSubtotal();
}

public class CartService : ICartService
{
    private readonly List<CartItem> _cartItems = [];

    public event EventHandler? CartUpdated;

    public List<CartItem> GetCartItems() => _cartItems.ToList();

    public void AddItem(MenuItem item)
    {
        var existingItem = _cartItems.FirstOrDefault(ci => ci.Item.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            _cartItems.Add(new CartItem { Item = item, Quantity = 1 });
        }
        CartUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(MenuItem item)
    {
        var cartItem = _cartItems.FirstOrDefault(ci => ci.Item.Id == item.Id);
        if (cartItem != null)
        {
            _cartItems.Remove(cartItem);
            CartUpdated?.Invoke(this, EventArgs.Empty);
        }
    }

    public void UpdateQuantity(MenuItem item, int quantity)
    {
        var cartItem = _cartItems.FirstOrDefault(ci => ci.Item.Id == item.Id);
        if (cartItem != null)
        {
            if (quantity <= 0)
            {
                RemoveItem(item);
            }
            else
            {
                cartItem.Quantity = quantity;
                CartUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void ClearCart()
    {
        _cartItems.Clear();
        CartUpdated?.Invoke(this, EventArgs.Empty);
    }

    public int GetTotalItems() => _cartItems.Sum(ci => ci.Quantity);

    public decimal GetSubtotal() => _cartItems.Sum(ci => ci.Total);
}
