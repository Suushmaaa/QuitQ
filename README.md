# QuitQ E-commerce Application

## 📌 Project Overview
QuitQ is a full-fledged e-commerce application developed using **ASP.NET Core Web API** and **MS SQL Server**. This project includes essential e-commerce features such as user authentication, product management, shopping cart, order processing, payment integration, and admin functionalities.

## 🔥 Features
### 🛒 Customer Features
- **User Authentication**: Secure login and registration using JWT authentication.
- **Product Browsing**: View available products with details and categories.
- **Shopping Cart**: Add, update, and remove items from the cart.
- **Order Processing**: Place orders, view order history, and track order status.
- **Secure Payments**: Integration with payment gateways for transactions.

### 🛠️ Admin Features
- **Product Management**: Add, update, and delete products.
- **Order Management**: View and update order status.
- **User Management**: Manage registered users and roles.
- **Logging & Monitoring**: Track application logs for better debugging.

## 🏗️ Tech Stack

- **Frontend:** react
- **Backend:** ASP.NET Core Web API
- **Database:** Microsoft SQL Server
- **Authentication:** JWT (JSON Web Token)


## 🚀 Setup & Installation
### Prerequisites
- .NET SDK 6.0 or later
- SQL Server (Local or Cloud)
- Visual Studio / VS Code

### Steps to Run the Project
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/your-username/QuitQ-Ecommerce.git
   cd QuitQ-Ecommerce
   ```
2. **Configure Database Connection:**
   - Update `appsettings.json` with your SQL Server connection string.
3. **Apply Migrations & Seed Data:**
   ```sh
   dotnet ef database update
   ```
4. **Run the Application:**
   ```sh
   dotnet run
   ```
5. **Access API Endpoints:**
   - Swagger UI: `https://localhost:5001/swagger`
   - API Base URL: `https://localhost:5001/api`

## 📜 API Endpoints
### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Authenticate and get JWT token

### Products
- `GET /api/products` - Get all products
- `POST /api/products` - Add a new product (Admin only)

### Cart
- `POST /api/cart/add` - Add item to cart
- `GET /api/cart` - View cart items

### Orders
- `POST /api/orders/place` - Place an order
- `GET /api/orders/{id}` - Get order details

## 🔐 Authentication & Authorization
- Uses **JWT** tokens for secure authentication.
- Role-based authorization for admin functionalities.

## 🛠️ Future Enhancements
- Implement real-time order tracking.
- Integrate AI-based product recommendations.
- Enhance UI with a frontend (React).

## 📌 Contributing
Contributions are welcome! Feel free to fork the repo and submit pull requests.
