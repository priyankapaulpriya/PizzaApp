using PizzaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaApp.Services;

public class ApiService
{
    public async Task<List<Pizza>> FetchPizzasAsync()
    {
        // Simulate a 1-second delay to mimic an API call
        await Task.Delay(1000);

        // Return mock data with images
        return new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Classic cheese pizza", Price = 8.99, Image = "margherita.png" },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni with mozzarella", Price = 9.99, Image = "pepperoni.png" },
            new Pizza { Id = 3, Name = "Veggie", Description = "Loaded with vegetables", Price = 10.49, Image = "veggie.png" },
        };
    }
}
