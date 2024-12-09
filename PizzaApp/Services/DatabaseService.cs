using PizzaApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaApp.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Pizza>().Wait(); // Ensure the table exists
    }

    public Task<List<Pizza>> GetPizzasAsync()
    {
        // Get all pizzas from the database
        return _database.Table<Pizza>().ToListAsync();
    }

    public Task<int> SavePizzaAsync(Pizza pizza)
    {
        // Insert or replace pizza into the database
        return _database.InsertOrReplaceAsync(pizza);
    }

    public Task<int> DeleteAllPizzasAsync()
    {
        // Delete all pizzas from the database
        return _database.DeleteAllAsync<Pizza>();
    }
}
