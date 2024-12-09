using PizzaApp.ViewModels;

namespace PizzaApp.Pages
{
    public partial class PizzaDetailsPage : ContentPage
    {
        public PizzaDetailsPage(PizzaDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
