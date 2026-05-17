using FoodDelivery.Models;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.Services;

public interface IRestaurantService
{
    List<Restaurant> GetAllRestaurants();
    Restaurant? GetRestaurantById(int id);
}

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> _restaurants =
    [
        new()
        {
            Id = 1,
            Name = "Umami Kitchen",
            Cuisine = "Japanese",
            Rating = 4.8,
            DeliveryTime = "25-35 min",
            ImageEmoji = "🍱",
            MinOrder = 15,
            DeliveryFee = 2.99m,
            MenuItems =
            [
                new MenuItem
                {
                    Id = 101, Name = "Dragon Roll", Description = "Shrimp tempura, avocado, eel sauce", Price = 14.99m,
                    ImageEmoji = "🍣", Category = "Sushi", IsPopular = true
                },
                new MenuItem
                {
                    Id = 102, Name = "Chicken Teriyaki", Description = "Grilled chicken with teriyaki glaze",
                    Price = 12.99m, ImageEmoji = "🍗", Category = "Main"
                },
                new MenuItem
                {
                    Id = 103, Name = "Miso Soup", Description = "Traditional soybean paste soup", Price = 3.99m,
                    ImageEmoji = "🍜", Category = "Soup"
                },
                new MenuItem
                {
                    Id = 104, Name = "Salmon Sashimi", Description = "Fresh sliced salmon", Price = 16.99m,
                    ImageEmoji = "🐟", Category = "Sushi", IsPopular = true
                },
                new MenuItem
                {
                    Id = 105, Name = "California Roll", Description = "Crab, avocado, cucumber", Price = 11.99m,
                    ImageEmoji = "🍣", Category = "Sushi"
                },
                new MenuItem
                {
                    Id = 106, Name = "Beef Ramen", Description = "Rich broth with tender beef slices", Price = 13.99m,
                    ImageEmoji = "🍜", Category = "Ramen", IsPopular = true
                },
                new MenuItem
                {
                    Id = 107, Name = "Tempura Platter", Description = "Assorted vegetables and shrimp", Price = 15.99m,
                    ImageEmoji = "🍤", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 108, Name = "Edamame", Description = "Steamed soybeans with sea salt", Price = 4.99m,
                    ImageEmoji = "🫛", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 109, Name = "Gyoza", Description = "Pan-fried pork dumplings", Price = 7.99m,
                    ImageEmoji = "🥟", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 110, Name = "Green Tea Ice Cream", Description = "Traditional Japanese dessert", Price = 5.99m,
                    ImageEmoji = "🍨", Category = "Dessert"
                }
            ]
        },

        new()
        {
            Id = 2,
            Name = "Bella Italia",
            Cuisine = "Italian",
            Rating = 4.6,
            DeliveryTime = "30-40 min",
            ImageEmoji = "🍝",
            MinOrder = 20,
            DeliveryFee = 1.99m,
            MenuItems = 
            [
                new MenuItem
                {
                    Id = 201, Name = "Margherita Pizza", Description = "Fresh mozzarella, basil, tomato",
                    Price = 13.99m, ImageEmoji = "🍕", Category = "Pizza", IsPopular = true
                },
                new MenuItem
                {
                    Id = 202, Name = "Spaghetti Carbonara", Description = "Creamy pasta with pancetta", Price = 15.99m,
                    ImageEmoji = "🍝", Category = "Pasta"
                },
                new MenuItem
                {
                    Id = 203, Name = "Tiramisu", Description = "Classic Italian dessert", Price = 6.99m,
                    ImageEmoji = "🍰", Category = "Dessert"
                },
                new MenuItem
                {
                    Id = 204, Name = "Caesar Salad", Description = "Romaine, parmesan, croutons", Price = 8.99m,
                    ImageEmoji = "🥗", Category = "Salad"
                },
                new MenuItem
                {
                    Id = 205, Name = "Pepperoni Pizza", Description = "Classic pepperoni with mozzarella", Price = 14.99m,
                    ImageEmoji = "🍕", Category = "Pizza", IsPopular = true
                },
                new MenuItem
                {
                    Id = 206, Name = "Fettuccine Alfredo", Description = "Rich cream sauce with parmesan", Price = 14.99m,
                    ImageEmoji = "🍝", Category = "Pasta"
                },
                new MenuItem
                {
                    Id = 207, Name = "Lasagna", Description = "Layers of pasta, meat, and cheese", Price = 16.99m,
                    ImageEmoji = "🍝", Category = "Pasta", IsPopular = true
                },
                new MenuItem
                {
                    Id = 208, Name = "Bruschetta", Description = "Toasted bread with tomato and basil", Price = 6.99m,
                    ImageEmoji = "🍞", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 209, Name = "Caprese Salad", Description = "Tomato, mozzarella, basil", Price = 9.99m,
                    ImageEmoji = "🥗", Category = "Salad"
                },
                new MenuItem
                {
                    Id = 210, Name = "Panna Cotta", Description = "Creamy vanilla custard dessert", Price = 7.99m,
                    ImageEmoji = "🍮", Category = "Dessert"
                }
            ]
        },

        new()
        {
            Id = 3,
            Name = "Spice Route",
            Cuisine = "Indian",
            Rating = 4.9,
            DeliveryTime = "20-30 min",
            ImageEmoji = "🍛",
            MinOrder = 18,
            DeliveryFee = 2.49m,
            MenuItems = 
            [
                new MenuItem
                {
                    Id = 301, Name = "Butter Chicken", Description = "Creamy tomato curry with tender chicken",
                    Price = 14.99m, ImageEmoji = "🍗", Category = "Curry", IsPopular = true
                },
                new MenuItem
                {
                    Id = 302, Name = "Garlic Naan", Description = "Fresh baked flatbread with garlic", Price = 3.99m,
                    ImageEmoji = "🫓", Category = "Bread"
                },
                new MenuItem
                {
                    Id = 303, Name = "Biryani", Description = "Fragrant basmati rice with spices", Price = 13.99m,
                    ImageEmoji = "🍚", Category = "Rice", IsPopular = true
                },
                new MenuItem
                {
                    Id = 304, Name = "Samosas", Description = "Crispy pastry with spiced potato filling", Price = 5.99m,
                    ImageEmoji = "🥟", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 305, Name = "Chicken Tikka Masala", Description = "Grilled chicken in rich tomato sauce", Price = 15.99m,
                    ImageEmoji = "🍛", Category = "Curry", IsPopular = true
                },
                new MenuItem
                {
                    Id = 306, Name = "Palak Paneer", Description = "Spinach curry with cottage cheese", Price = 12.99m,
                    ImageEmoji = "🥬", Category = "Curry"
                },
                new MenuItem
                {
                    Id = 307, Name = "Tandoori Chicken", Description = "Clay oven roasted chicken", Price = 14.99m,
                    ImageEmoji = "🍗", Category = "Main"
                },
                new MenuItem
                {
                    Id = 308, Name = "Chana Masala", Description = "Spiced chickpea curry", Price = 11.99m,
                    ImageEmoji = "🫘", Category = "Curry"
                },
                new MenuItem
                {
                    Id = 309, Name = "Mango Lassi", Description = "Sweet yogurt drink with mango", Price = 4.99m,
                    ImageEmoji = "🥭", Category = "Drinks"
                },
                new MenuItem
                {
                    Id = 310, Name = "Gulab Jamun", Description = "Sweet fried dough balls in syrup", Price = 5.99m,
                    ImageEmoji = "🍡", Category = "Dessert"
                }
            ]
        },

        new()
        {
            Id = 4,
            Name = "Burger Palace",
            Cuisine = "American",
            Rating = 4.7,
            DeliveryTime = "15-25 min",
            ImageEmoji = "🍔",
            MinOrder = 12,
            DeliveryFee = 1.49m,
            MenuItems = 
            [
                new MenuItem
                {
                    Id = 401, Name = "Classic Cheeseburger", Description = "Beef patty, cheddar, lettuce, tomato",
                    Price = 9.99m, ImageEmoji = "🍔", Category = "Burgers", IsPopular = true
                },
                new MenuItem
                {
                    Id = 402, Name = "Loaded Fries", Description = "Crispy fries with cheese and bacon", Price = 6.99m,
                    ImageEmoji = "🍟", Category = "Sides"
                },
                new MenuItem
                {
                    Id = 403, Name = "Chicken Wings", Description = "Spicy buffalo wings", Price = 11.99m,
                    ImageEmoji = "🍗", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 404, Name = "Milkshake", Description = "Creamy vanilla shake", Price = 4.99m,
                    ImageEmoji = "🥤", Category = "Drinks"
                },
                new MenuItem
                {
                    Id = 405, Name = "Bacon Burger", Description = "Double beef with crispy bacon", Price = 12.99m,
                    ImageEmoji = "🍔", Category = "Burgers", IsPopular = true
                },
                new MenuItem
                {
                    Id = 406, Name = "Veggie Burger", Description = "Plant-based patty with fresh veggies", Price = 10.99m,
                    ImageEmoji = "🥗", Category = "Burgers"
                },
                new MenuItem
                {
                    Id = 407, Name = "Onion Rings", Description = "Crispy battered onion rings", Price = 5.99m,
                    ImageEmoji = "🧅", Category = "Sides"
                },
                new MenuItem
                {
                    Id = 408, Name = "Mac & Cheese", Description = "Creamy macaroni and cheese", Price = 7.99m,
                    ImageEmoji = "🧀", Category = "Sides"
                },
                new MenuItem
                {
                    Id = 409, Name = "Chicken Sandwich", Description = "Crispy fried chicken breast", Price = 10.99m,
                    ImageEmoji = "🥪", Category = "Sandwiches"
                },
                new MenuItem
                {
                    Id = 410, Name = "Chocolate Shake", Description = "Rich chocolate milkshake", Price = 4.99m,
                    ImageEmoji = "🍫", Category = "Drinks"
                }
            ]
        },

        new()
        {
            Id = 5,
            Name = "Taco Fiesta",
            Cuisine = "Mexican",
            Rating = 4.5,
            DeliveryTime = "20-30 min",
            ImageEmoji = "🌮",
            MinOrder = 15,
            DeliveryFee = 2.29m,
            MenuItems = 
            [
                new MenuItem
                {
                    Id = 501, Name = "Beef Tacos", Description = "3 soft tacos with seasoned beef", Price = 8.99m,
                    ImageEmoji = "🌮", Category = "Tacos", IsPopular = true
                },
                new MenuItem
                {
                    Id = 502, Name = "Chicken Burrito", Description = "Large burrito with rice and beans",
                    Price = 11.99m, ImageEmoji = "🌯", Category = "Burritos"
                },
                new MenuItem
                {
                    Id = 503, Name = "Guacamole", Description = "Fresh avocado dip with chips", Price = 5.99m,
                    ImageEmoji = "🥑", Category = "Sides"
                },
                new MenuItem
                {
                    Id = 504, Name = "Churros", Description = "Fried dough with cinnamon sugar", Price = 4.99m,
                    ImageEmoji = "🍩", Category = "Dessert"
                },
                new MenuItem
                {
                    Id = 505, Name = "Carnitas Tacos", Description = "Slow-cooked pork tacos", Price = 9.99m,
                    ImageEmoji = "🌮", Category = "Tacos", IsPopular = true
                },
                new MenuItem
                {
                    Id = 506, Name = "Quesadilla", Description = "Cheese and chicken in tortilla", Price = 10.99m,
                    ImageEmoji = "🫔", Category = "Appetizer"
                },
                new MenuItem
                {
                    Id = 507, Name = "Nachos Supreme", Description = "Chips with cheese, beef, sour cream", Price = 12.99m,
                    ImageEmoji = "🧀", Category = "Appetizer", IsPopular = true
                },
                new MenuItem
                {
                    Id = 508, Name = "Fish Tacos", Description = "Grilled fish with cabbage slaw", Price = 11.99m,
                    ImageEmoji = "🐟", Category = "Tacos"
                },
                new MenuItem
                {
                    Id = 509, Name = "Elote", Description = "Mexican street corn", Price = 4.99m,
                    ImageEmoji = "🌽", Category = "Sides"
                },
                new MenuItem
                {
                    Id = 510, Name = "Horchata", Description = "Sweet rice milk drink", Price = 3.99m,
                    ImageEmoji = "🥛", Category = "Drinks"
                }
            ]
        }
    ];

    public List<Restaurant> GetAllRestaurants() => _restaurants;

    public Restaurant? GetRestaurantById(int id) => _restaurants.FirstOrDefault(r => r.Id == id);
}