using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;

namespace PizzaApp.ViewModels;

[QueryProperty(nameof(SelectedPizza), "SelectedPizza")]
public partial class PizzaDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private Pizza selectedPizza;
}
