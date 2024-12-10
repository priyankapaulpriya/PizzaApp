
---

Name - Priyanka Paul ,Student ID - A00287707

# **PizzaApp**

PizzaApp is a .NET MAUI application demonstrating a pizza menu system using **MVVM architecture**, **API integration**, and **SQLite database storage**. It allows users to view pizza details, fetch data from an API, store the data locally for offline use, and navigate to a static "Contact Us" page.

---

## **Features**

- **Modern UI** built with .NET MAUI.
- Implements **MVVM architecture** for a clean separation of concerns.
- Fetches pizza data from a **mock API**.
- Stores pizza data in **SQLite** for offline access.
- Includes navigation between pages using **Shell Routing**.
- A **static "Contact Us" page** showcasing Shell navigation and UI design.

---

## **Architecture**

The project adheres to the **MVVM (Model-View-ViewModel)** architecture:

1. **Model**:
   - Represents the pizza data structure (e.g., name, description, price, and image).
2. **View**:
   - XAML pages for the UI, including data binding to ViewModels.
3. **ViewModel**:
   - Contains logic to fetch, store, and manipulate data, as well as commands for user interactions.

---

## **Screens**

### **1. Home Page**
- Displays a list of pizzas dynamically loaded using API and SQLite.
- Features a button to load data from the API.
- Includes a link to navigate to the **Contact Us** page.

### **2. Pizza Details Page**
- Displays detailed information about a selected pizza.
- Implements navigation from the Home Page using Shell Routing.

### **3. Contact Us Page**
- A static page with dummy contact information.
- Linked from the Home Page for easy navigation.

---

## **Core Functionalities**

### **1. MVVM Implementation**
- **HomePage.xaml**:
  - Binds to `HomeViewModel`.
  - Uses `CollectionView` to dynamically display pizza data.
- **HomeViewModel.cs**:
  - Fetches pizza data from the API or SQLite and updates the UI.
  - Implements commands for loading data and navigation.

### **2. Navigation Between Pages**
- **Shell Routing**:
  - Defined in `AppShell.xaml` for smooth navigation between pages.
  - Example:
    ```xml
    <ShellContent Title="Contact Us" ContentTemplate="{DataTemplate pages:ContactUsPage}" Route="ContactUsPage" />
    ```
- **Navigation Command**:
  - Example from `HomeViewModel`:
    ```csharp
    [RelayCommand]
    public async Task NavigateToContactUs()
    {
        await Shell.Current.GoToAsync("ContactUsPage");
    }
    ```

### **3. API Consumption**
- **ApiService.cs**:
  - Simulates fetching pizza data from a RESTful API.
  - Example:
    ```csharp
    public async Task<List<Pizza>> FetchPizzasAsync()
    {
        await Task.Delay(1000);
        return new List<Pizza>
        {
            new Pizza { Name = "Margherita", Description = "Cheese pizza", Price = 8.99 },
            // More pizzas...
        };
    }
    ```

### **4. SQLite Database Integration**
- **DatabaseService.cs**:
  - Handles CRUD operations for storing pizza data.
  - Example:
    ```csharp
    public Task<int> SavePizzaAsync(Pizza pizza)
    {
        return _database.InsertOrReplaceAsync(pizza);
    }
    ```

- **Offline Functionality**:
  - Loads pizza data from SQLite when the API is unavailable.

### **5. Contact Us Page**
- **ContactUsPage.xaml**:
  - A static page with dummy contact information.
  - Example content:
    ```xml
    <Label Text="Email: contact@pizzaapp.com" FontSize="16" />
    <Label Text="Phone: +1 123-456-7890" FontSize="16" />
    ```

---

## **How the Requirements Are Fulfilled**

### **1. Implementation of MVVM**
- **Models**: Represents pizza data.
- **ViewModels**: Handles logic, such as fetching data and managing navigation.
- **Views**: UI pages bound to ViewModels for dynamic updates.

### **2. Navigation Between Pages**
- Uses Shell Routing for seamless navigation:
  - Home Page -> Pizza Details Page.
  - Home Page -> Contact Us Page.

### **3. API Consumption**
- Fetches pizza data using a simulated RESTful API (`ApiService`).
- Dynamically updates the UI based on API responses.

### **4. SQLite Database Integration**
- Stores pizza data locally using SQLite for offline functionality.
- Data persists between app sessions.

---

## **Setup and Installation**

### **Prerequisites**
- **Visual Studio 2022** with .NET MAUI workload installed.
- NuGet Packages:
  - `sqlite-net-pcl`
  - `CommunityToolkit.Mvvm`

### **Steps to Run the App**
1. Clone the repository.
2. Open the solution in Visual Studio (`PizzaApp.sln`).
3. Restore NuGet packages (`Tools > NuGet Package Manager > Manage NuGet Packages for Solution`).
4. Build the solution (`Build > Rebuild Solution`).
5. Run the app on an emulator, simulator, or local machine.

---

## **Folder Structure**

- **Models**:
  - `Pizza.cs`: Represents pizza data (e.g., name, description, price, image).
- **ViewModels**:
  - `HomeViewModel.cs`: Handles logic for the Home Page.
  - `PizzaDetailsViewModel.cs`: Handles logic for the Pizza Details Page.
- **Pages (Views)**:
  - `HomePage.xaml`: Displays the list of pizzas and navigation links.
  - `PizzaDetailsPage.xaml`: Shows detailed pizza information.
  - `ContactUsPage.xaml`: Static page with contact information.
- **Services**:
  - `ApiService.cs`: Fetches pizza data from a mock API.
  - `DatabaseService.cs`: Handles SQLite operations.

---

## **Future Enhancements**

- Integrate a real API for fetching pizza data.
- Add advanced UI features like filtering and sorting.
- Enhance offline capabilities with more robust error handling.

---

Let me know if you need further modifications!
