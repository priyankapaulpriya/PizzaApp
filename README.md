---

# **PizzaApp**

PizzaApp is a .NET MAUI application designed to demonstrate a pizza menu system using **MVVM architecture**, **API integration**, and **SQLite database storage**. It allows users to view pizza details, fetch data from an API, and store the data locally for offline use.

---

## **Features**
- **Modern UI** with .NET MAUI.
- Implements **MVVM architecture** for separation of concerns.
- Fetches pizza data from a **mock API**.
- Stores and retrieves pizza data using **SQLite** for offline access.
- Dynamically updates the UI with data bindings.

---

## **Architecture**
The project follows the **MVVM (Model-View-ViewModel)** pattern:
1. **Model**:
   - Represents the pizza data (e.g., name, description, price, image).
2. **View**:
   - Contains the UI elements (XAML files) to display the data.
3. **ViewModel**:
   - Contains the logic and data binding to connect the Model and the View.

---

## **Screens**
1. **Home Page**:
   - A list of pizzas loaded dynamically.
   - Button to fetch data using the API.
   - Displays pizza details including images, descriptions, and prices.

   **Key Components**:
   - **MVVM Binding**: The list of pizzas is bound to the `Pizzas` property in the `HomeViewModel`.
   - **API Integration**: Data is fetched from the `ApiService`.
   - **SQLite Integration**: Data is stored locally for offline use.

2. **Details Page**:
   - Displays detailed information about a selected pizza.
   - Uses shell routing to navigate to this page.

---

## **Core Functionalities**
### **1. MVVM Implementation**
- **HomePage.xaml**:
   - Binds to `HomeViewModel`.
   - Uses data bindings to display pizzas dynamically in a `CollectionView`.

- **HomeViewModel.cs**:
   - Fetches data from the API or SQLite and updates the `Pizzas` observable collection.
   - Implements commands for data loading and navigation.

   Example:
   ```csharp
   public ObservableCollection<Pizza> Pizzas { get; set; } = new();
   ```

- **Pizza.cs (Model)**:
   - Represents the structure of pizza data.

### **2. Navigation Between Pages**
- **AppShell.xaml**:
   - Configures shell-based navigation.
   - Example:
     ```xml
     <ShellContent Title="Home" ContentTemplate="{DataTemplate pages:HomePage}" Route="HomePage" />
     <ShellContent Title="Details" ContentTemplate="{DataTemplate pages:PizzaDetailsPage}" Route="PizzaDetailsPage" />
     ```

- **Navigation Command**:
   - Example:
     ```csharp
     await Shell.Current.GoToAsync("PizzaDetailsPage", parameters);
     ```

### **3. API Consumption**
- **ApiService.cs**:
   - Simulates a RESTful API call to fetch pizza data.
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

- **Key Feature**:
   - Fetches data from the mock API and stores it locally.

### **4. SQLite Database Integration**
- **DatabaseService.cs**:
   - Handles SQLite operations (CRUD).
   - Example:
     ```csharp
     public Task<int> SavePizzaAsync(Pizza pizza)
     {
         return _database.InsertOrReplaceAsync(pizza);
     }
     ```

- **Offline Functionality**:
   - If the API is unavailable, data is loaded from SQLite.

---

## **Usage Instructions**

### **1. Prerequisites**
- Install **Visual Studio 2022** with the .NET MAUI workload.
- Ensure the following NuGet packages are installed:
  - `sqlite-net-pcl`
  - `CommunityToolkit.Mvvm`

### **2. Running the App**
1. Clone the repository.
2. Open the solution file (`PizzaApp.sln`) in Visual Studio.
3. Build the solution (`Build > Rebuild Solution`).
4. Run the app (`Debug > Start Debugging`).

---

## **Folder Structure**
- **Models**:
  - Contains the `Pizza.cs` class representing pizza data.
- **ViewModels**:
  - Contains `HomeViewModel.cs` and `PizzaDetailsViewModel.cs` for data binding and logic.
- **Views (Pages)**:
  - Contains `HomePage.xaml` and `PizzaDetailsPage.xaml` for the UI.
- **Services**:
  - `ApiService.cs`: Fetches data from the mock API.
  - `DatabaseService.cs`: Manages SQLite operations.

---

## **Screenshots**

1. **Home Page**:
   ![Home Page](https://via.placeholder.com/300x600?text=Home+Page+with+Pizzas)
2. **Details Page**:
   ![Details Page](https://via.placeholder.com/300x600?text=Details+Page+with+Pizza+Details)

---

## **How the Requirements Are Fulfilled**

### **Implementation of MVVM**
- The project strictly follows the MVVM architecture.
- **Models** represent pizza data.
- **ViewModels** handle logic and data binding.
- **Views** display data using XAML bindings.

### **Navigation Between Pages**
- Uses Shell navigation (`AppShell.xaml`).
- Passes data between pages using shell routing and query properties.

### **API Consumption**
- The `ApiService` simulates fetching data from an API.
- Dynamically updates the UI based on the fetched data.

### **SQLite Database**
- Data is saved to SQLite for offline use.
- Fetches data from SQLite if the API is unavailable.

---

## **Future Enhancements**
- Integrate a real API for fetching pizza data.
- Add advanced UI features like animations and filtering.
- Implement error messages and loading spinners for better UX.

---
