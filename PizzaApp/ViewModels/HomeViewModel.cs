using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaApp.Models;
using PizzaApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PizzaApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ApiService _apiService;
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Pizza> Pizzas { get; set; } = new();

    // Add the IsLoading property
    [ObservableProperty]
    private bool isLoading;

    public HomeViewModel(ApiService apiService, DatabaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
    }

    [RelayCommand]
    public async Task LoadPizzasAsync()
    {
        try
        {
            IsLoading = true; // Start loading

            // Clear existing pizzas
            Pizzas.Clear();

            // Step 1: Load pizzas from SQLite
            var localPizzas = await _databaseService.GetPizzasAsync();
            if (localPizzas.Count > 0)
            {
                foreach (var pizza in localPizzas)
                {
                    Pizzas.Add(pizza);
                }
                Console.WriteLine("Loaded pizzas from SQLite");
            }

            // Step 2: Fetch pizzas from API
            var apiPizzas = await _apiService.FetchPizzasAsync();
            if (apiPizzas != null && apiPizzas.Count > 0)
            {
                await _databaseService.DeleteAllPizzasAsync();
                foreach (var pizza in apiPizzas)
                {
                    await _databaseService.SavePizzaAsync(pizza);
                    Pizzas.Add(pizza);
                }
                Console.WriteLine("Loaded pizzas from API and saved to SQLite");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading pizzas: {ex.Message}");
        }
        finally
        {
            IsLoading = false; // Stop loading
        }
    }
}
