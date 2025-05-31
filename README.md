# Ecommerce API - .NET 8

[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![JWT Authentication](https://img.shields.io/badge/Auth-JWT-orange)](https://jwt.io/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A RESTful ecommerce API built with .NET 8 featuring JWT authentication, basket management, and order processing.

## Features

### 🔒 Authentication
- User registration and login
- JWT token generation and validation
- Email availability checking
- Current user endpoint

### 🧺 Basket System
- Create/update basket
- Retrieve user's basket
- Delete basket items
- 🔐 *All endpoints require valid JWT token*

### 📦 Order Management
*(All operations are for the current logged-in user)*

- **Create new orders**  
  `POST /api/orders` - Submit new order with products  
  *Validates: product exists, quantity > 0, valid address*

- **Retrieve order history**  
  `GET /api/orders` - Get all your orders  
  `GET /api/orders/{id}` - Get specific order by ID  

- **Get delivery methods**  
  `GET /api/orders/DeliveryMethods` - Available shipping options  

- 🔐 *All endpoints require valid JWT token*

### 🏷️ Products
- Product catalog with:
  - Name, description, price
  - Brand information
  - Product images
  - 🔐 *All endpoints require valid JWT token*

## Tech Stack
- **Framework**: ASP.NET Core 8
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer Tokens
- **Validation**: FluentValidation
- **API Documentation**: Swagger UI

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server

## 📸 UI Gallery

### 🔐 Authentication End Points
<img src="screenshots/Authentication.png"  alt="Authentication end points">  

### 🧺 Basket End Points
<img src="screenshots/Basket.png"  alt="Basket end points">  

### 📦 Orders End Points
<img src="screenshots/Orders.png"  alt="Orders end points">  

### 🏷️ Products End Points
<img src="screenshots/Products.png"  alt="Products end points">  

## Contact with me

<div align="left">
  <a href="mailto:gamalhanafi26@gmail.com" target="_blank">
    <img src="https://img.shields.io/static/v1?message=Gmail&logo=gmail&label=&color=D14836&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="gmail logo"  />
  </a>
  <a href="https://www.linkedin.com/in/gamal-hanafi-56993a268/" target="_blank">
    <img src="https://img.shields.io/static/v1?message=LinkedIn&logo=linkedin&label=&color=0077B5&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="linkedin logo"  />
  </a>
</div>
