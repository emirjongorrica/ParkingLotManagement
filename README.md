# 🚗 Parking Lot Management App

This is a web-based Parking Lot Management System built using **ASP.NET Core MVC** and **Entity Framework Core**. It aims to digitize and streamline operations such as check-ins/check-outs, subscriptions, pricing, and spot availability.

### 📌 Features

- Track regular and reserved parking spots
- Manage weekday/weekend pricing plans
- Handle subscriber registrations and monthly subscriptions
- Record daily parking logs with automated price calculation
- Grace period logic for free short stays
- Real-time spot availability calculations
- Soft deletion for subscribers and logs

### 🚀 How to Run

1. Clone the repository
2. Set up the connection string in `appsettings.json`
3. Run migrations:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
4. Run the project from Visual Studio or:
    ```bash
    dotnet run
    ```
