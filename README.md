[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/QO7LV3O3)

# Factual Overview

This is a comprehensive e-commerce platform developed with a decoupled architecture. The project includes a robust RESTful API built with ASP.NET Core and a web client interface using Razor Pages. The system manages secure authentication, a product catalog, and a persistent shopping cart.

## Software Architecture

The project follows a layered architecture promoting separation of concerns (SoC) and adherence to SOLID principles:

- **Repository Pattern**: Data access is encapsulated in repositories (`DbProductsRepository`, `DbUsersRepository`, `DbShopingCartRepository`), isolating persistence logic from the rest of the application.
- **Service Layer**: An intermediate service layer (`ProductService`, `UsersService`, `ShoppingCartService`) handles business logic between API controllers and repositories.
- **Data Transfer Objects (DTOs)**: Systematic use of DTOs for data transfer between the client and API, avoiding direct exposure of database models.
- **Security**: Implementation of JWT (JSON Web Tokens) authentication and secure password hashing.

## Technical Specifications

### Backend (API)
- **Framework**: ASP.NET Core 8.0.
- **ORM**: Entity Framework Core with migration support.
- **Security**: Role management (Admin/User) and automatic initialization of an administrator account.

### Frontend (Web)
- **Framework**: ASP.NET Core Razor Pages.
- **UI**: Bootstrap integration for a responsive interface.
- **API Interaction**: Asynchronous consumption of API services for CRUD operations and cart management.

## Main Features

- **Product Catalog**: Full management of products (create, read, update, delete) with data validation.
- **Cart System**: Add products, update quantities, and automatic total calculation.
- **User Management**: Registration, login, and user account administration.
- **SQL Persistence**: Seeding scripts provided to initialize products and test users.

## Installation and Configuration

- **Prerequisites**: .NET 8.0 SDK and a SQL Server instance.
- **Database Configuration**: Adjust the connection string in the API's `appsettings.json`.
- **Migrations**: Run `dotnet ef database update` to create the schema.
- **Startup**:
    - **API**: `dotnet run --project 521.tpfinal.api`
    - **Web**: `dotnet run --project 521.tpfinal.web`

## Default Administrator Account

| Field        | Value                       |
|--------------|----------------------------|
| **Email**    | `zyphorah.admin@gmail.com`  |
| **Password** | `Uj@l&l**^1M@*1KG`         |

> **Note**: This account is automatically created on the API's first startup.
