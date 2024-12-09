using SQLite;

namespace PizzaApp.Models;

public class Pizza
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; } // For pizza images
}
