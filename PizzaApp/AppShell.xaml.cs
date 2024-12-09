namespace PizzaApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Explicit route registration
        Routing.RegisterRoute("ContactUsPage", typeof(PizzaApp.Pages.ContactUsPage));
    }
}
