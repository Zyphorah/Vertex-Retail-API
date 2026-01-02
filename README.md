[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/QO7LV3O3)

# Présentation Factuelle

C'est une plateforme de commerce électronique complète développée avec une architecture découplée. Le projet comprend une API RESTful robuste construite en ASP.NET Core et une interface client Web utilisant Razor Pages. Le système gère l'authentification sécurisée, le catalogue de produits, et un panier d'achat persistant.

## Architecture Logicielle

Le projet suit une architecture en couches favorisant la séparation des préoccupations (SoC) et le respect des principes SOLID :

- **Pattern Repository** : L'accès aux données est encapsulé dans des dépôts (`DbProductsRepository`, `DbUsersRepository`, `DbShopingCartRepository`), isolant la logique de persistance du reste de l'application.
- **Couche de Service** : Une couche intermédiaire de services (`ProductService`, `UsersService`, `ShoppingCartService`) gère la logique d'affaires entre les contrôleurs API et les dépôts.
- **Data Transfer Objects (DTO)** : Utilisation systématique de DTO pour le transfert de données entre le client et l'API, évitant l'exposition directe des modèles de base de données.
- **Sécurité** : Implémentation de l'authentification par jetons JWT (JSON Web Tokens) et hachage sécurisé des mots de passe.

## Spécifications Techniques

### Backend (API)
- **Framework** : ASP.NET Core 8.0.
- **ORM** : Entity Framework Core avec support pour les migrations.
- **Sécurité** : Gestion des rôles (Admin/User) et initialisation automatique d'un compte administrateur.

### Frontend (Web)
- **Framework** : ASP.NET Core Razor Pages.
- **UI** : Intégration de Bootstrap pour une interface responsive.
- **Interaction API** : Consommation asynchrone des services de l'API pour les opérations CRUD et la gestion du panier.

## Fonctionnalités Principales

- **Catalogue de Produits** : Gestion complète des produits (création, lecture, mise à jour, suppression) avec validation des données.
- **Système de Panier** : Ajout de produits, mise à jour des quantités et calcul automatique des totaux.
- **Gestion des Utilisateurs** : Inscription, connexion, et administration des comptes utilisateurs.
- **Persistance SQL** : Scripts de semence (seeding) fournis pour initialiser les produits et les utilisateurs de test.

## Installation et Configuration

- **Prérequis** : .NET 8.0 SDK et une instance SQL Server.
- **Configuration de la base de données** : Ajuster la chaîne de connexion dans `appsettings.json` de l'API.
- **Migrations** : Exécuter `dotnet ef database update` pour créer le schéma.
- **Lancement** :
    - **API** : `dotnet run --project 521.tpfinal.api`
    - **Web** : `dotnet run --project 521.tpfinal.web`

## Compte Administrateur par défaut

| Champ        | Valeur                      |
|--------------|-----------------------------|
| **Email**    | `zyphorah.admin@gmail.com`  |
| **Mot de passe** | `Uj@l&l**^1M@*1KG`      |

> **Note** : Ce compte est créé automatiquement au premier démarrage de l'API.

---

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
