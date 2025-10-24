# School Management System API 🏫

This project is an ASP.NET Core Web API designed to manage school-related data, including students, persons, users, and roles. It provides a RESTful interface for performing CRUD (Create, Read, Update, Delete) operations on these entities. The API uses Entity Framework Core for database interactions and JWT (JSON Web Tokens) for authentication and authorization.

## 🚀 Key Features

- **User Authentication and Authorization:** Secure user management with registration, login, and role-based access control using JWT.
- **CRUD Operations for Students:** API endpoints for creating, reading, updating, and deleting student records.
- **CRUD Operations for Persons:** API endpoints for managing personal information, shared across students, teachers, and staff.
- **Database Management:** Utilizes Entity Framework Core for seamless database interactions.
- **Token Refreshing:** Implements refresh token mechanism for maintaining user sessions securely.
- **Asynchronous Operations:** Leverages `async` and `await` for non-blocking database operations, improving performance.
- **API Documentation:** Includes Swagger/OpenAPI for easy API exploration and testing.

## 🛠️ Tech Stack

- **Backend:**
    - ASP.NET Core Web API
    - .NET 9
- **Database:**
    - Entity Framework Core
- **Authentication:**
    - JWT (JSON Web Tokens)
    - Microsoft.AspNetCore.Authentication.JwtBearer
- **Security:**
    - BCrypt.Net (for password hashing)
- **API Documentation:**
    - Swagger/OpenAPI

## 📦 Getting Started

Follow these instructions to get the project up and running on your local machine.

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- An IDE such as Visual Studio or Visual Studio Code
- A database system (e.g., SQL Server)

### Installation

1.  Clone the repository:

    ```bash
    git clone https://github.com/RiteshGTM/SchoolManagementSystem/
    ```

2.  Navigate to the API project directory:

    ```bash
    cd SchoolManagementSystem
    cd SchoolManagementSystem.API
    ```

3.  Update the database connection string in `appsettings.json` with your database credentials.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=School;User Id=your_user_id;Password=your_password;"
      },
      "JwtSettings": {
        "Issuer": "your_issuer",
        "Audience": "your_audience",
        "SecretKey": "your_secret_key",
        "ExpiryMinutes": 60
      }
    }
    ```

4.  Apply database migrations:

    ```bash
    dotnet ef database update
    ```

### Running Locally

1.  Build the project:

    ```bash
    dotnet build
    ```

2.  Run the project:

    ```bash
    dotnet run
    ```

3.  Open your browser and navigate to `https://localhost:<port>/swagger` to access the Swagger UI and test the API endpoints. Replace `<port>` with the port number your application is running on (typically 5085 for HTTP).

## 📂 Project Structure

```
SchoolManagementSystem.API/
├── Controllers/
│   ├── AuthController.cs
│   ├── PersonController.cs
│   └── StudentController.cs
├── Data/
│   └── SchoolDbContext.cs
├── Models/
│   ├── Auth/
│   │   ├── RefreshToken.cs
│   │   ├── Role.cs
│   │   ├── User.cs
│   │   └── UserRole.cs
│   ├── Person.cs
│   └── Student.cs
├── DTOs/
│   ├── LoginRequest.cs
│   └── RegisterRequest.cs
├── Interfaces/
│   ├── IAuthService.cs
│   ├── IPersonRepository.cs
│   ├── IPersonService.cs
│   ├── IStudentRepository.cs
│   ├── IStudentService.cs
│   ├── IUserRepository.cs
│   └── IJwtTokenService.cs
├── Repositories/
│   ├── PersonRepository.cs
│   └── StudentRepository.cs
├── Services/
│   ├── AuthService.cs
│   ├── PersonService.cs
│   ├── StudentService.cs
│   └── JwtTokenService.cs
├── appsettings.json
├── Program.cs
└── SchoolManagementSystem.API.csproj
```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with descriptive messages.
4.  Push your changes to your fork.
5.  Submit a pull request to the main repository.

## 📬 Contact

For questions or feedback, please contact: Ritesh - ritesh.gtmcs@gmail.com

## 💖 Thanks

Thank you for checking out the School Management System API! We hope it's helpful for your projects.
