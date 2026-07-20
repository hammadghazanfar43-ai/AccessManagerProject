# 🔐 AccessManager

A secure **ASP.NET Core MVC** and **Web API** application developed to manage user authentication and form submissions. The project demonstrates modern full-stack development practices including **JWT Authentication**, **Repository Pattern**, **Entity Framework Core**, **SQL Server**, **AJAX CRUD Operations**, and **Swagger API Documentation**.

---

# 📌 Project Overview

AccessManager is a secure web application that enables users to register, authenticate, submit personal information, and manage records through a responsive dashboard.

The application also provides RESTful APIs secured with JWT Bearer Authentication, making it suitable for integration with mobile or third-party applications.

---

# ✨ Features

## 🔐 Authentication

- User Registration
- Secure Login
- BCrypt Password Hashing
- JWT Token Authentication
- Protected API Endpoints
- Unique Username & Email Validation

---

## 📝 Form Management

- Submit Personal Information
- Upload Profile Picture
- Country & City Dropdowns
- Dynamic Nationality & Country Code
- Edit Submitted Records
- Delete Records
- View Record Details

---

## 📧 Email Functionality

- Send Form Details via Email
- Email Status Tracking
- Pending / Sent / Failed Status

---

## 📊 Dashboard

- Responsive Dashboard
- AJAX Form Submission
- DataTables Search
- Pagination
- Toastr Notifications
- Bootstrap UI

---

## 🌐 REST API

- JWT Secured APIs
- CRUD Operations
- JSON Responses
- Swagger Documentation

---

## 🛡 Security Features

- JWT Bearer Authentication
- BCrypt Password Hashing
- Global Input Sanitization Filter
- IP Rate Limiting
- SQL Injection Protection
- Entity Validation

---

# 🛠 Technologies Used

- ASP.NET Core MVC
- ASP.NET Core Web API
- C#
- .NET 8
- Entity Framework Core
- SQL Server
- Repository Pattern
- JWT Authentication
- BCrypt.Net
- Swagger (OpenAPI)
- Bootstrap 5
- jQuery
- AJAX
- DataTables
- Toastr Notifications
- Visual Studio 2022

---

# 📂 Project Structure

```
AccessManager
│
├── AccessManager.API
├── AccessManager.Core
├── AccessManager.Infrastructure
├── AccessManager.Web
├── Models
└── SQL Server Database
```



---

# 🚀 Getting Started

## Clone Repository

```bash
git clone https://github.com/hammadghazanfar43-ai/AccessManagerProject.git
```

---

## Open Solution

Open the solution in **Visual Studio 2022**.

---

## Configure Database

Update your SQL Server connection string inside:

```
appsettings.json
```

---

## Apply Database Migration

```powershell
Update-Database
```

---

## Run the Project

Press **F5**

or

```bash
dotnet run
```

---

# 🔑 API Authentication

### Login Endpoint

```
POST /api/auth/login
```

After login you will receive a JWT Token.

Open Swagger.

Click **Authorize**

Paste

```
Bearer YOUR_TOKEN
```

Now you can access protected endpoints.

---

# 📌 API Endpoints

## Authentication

| Method | Endpoint |
|---------|-----------|
| POST | /api/auth/login |

---

## Form Submission

| Method | Endpoint |
|---------|-----------|
| GET | /api/FormSubmission |
| GET | /api/FormSubmission/{id} |
| POST | /api/FormSubmission |
| PUT | /api/FormSubmission/{id} |
| DELETE | /api/FormSubmission/{id} |

---

# 📈 Highlights

- Secure JWT Authentication
- Repository Pattern Architecture
- RESTful API Development
- AJAX-based CRUD Operations
- SQL Server Integration
- Entity Framework Core
- Responsive Bootstrap UI
- Swagger API Testing
- DataTables Integration
- Input Validation
- Password Encryption using BCrypt
- IP Rate Limiting
- Clean Layered Architecture

---

# 👨‍💻 Author

## Hammad Ghazanfar

**Software Engineer**

📧 Email

hammadghazanfar43@gmail.com

🔗 LinkedIn

https://www.linkedin.com/in/hammad-ghazanfar-804bb8321

💻 GitHub

https://github.com/hammadghazanfar43-ai

---

# ⭐ Future Improvements

- Role-Based Authorization
- Refresh Token Authentication
- Docker Support
- Azure Deployment
- Unit Testing
- CI/CD Pipeline
- Admin Panel
- Cloud File Storage
- Logging with Serilog

---

## ⭐ If you found this project useful, please consider giving it a Star.
