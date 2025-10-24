# School Management System

A full-stack School Management System application built with a .NET 9 API backend and an Angular frontend. This system provides functionalities for managing school-related data, including students and staff, with a robust JWT-based authentication system.

## About The Project

This project is a comprehensive solution for school administration. It is divided into two main parts:

*   **`SchoolManagementSystem.API`**: A RESTful API built with ASP.NET Core 9 that handles all business logic and data persistence. It uses Entity Framework Core to interact with a SQL Server database.
*   **`SchoolManagementSystem.UI`**: A single-page application built with Angular that provides the user interface for interacting with the API.

### Key Features

*   **User Authentication**: Secure user registration and login using JSON Web Tokens (JWT).
*   **Token Management**: Support for access and refresh tokens, including token refresh and revocation.
*   **Role-Based Access Control**: Differentiated permissions for users, such as `Admin` and `Student` roles. For example, deleting a student is restricted to Admins.
*   **Student Management**: Full CRUD (Create, Read, Update, Delete) operations for student records.
*   **Person Management**: CRUD operations for personal information, forming the base for students, teachers, and parents.
*   **Structured Database**: A well-defined database schema using Entity Framework Core migrations, including tables for users, roles, students, teachers, classes, and more.

### Built With

**Backend**
*   .NET 9
*   ASP.NET Core Web API
*   Entity Framework Core 9
*   SQL Server
*   BCrypt.Net (for password hashing)
*   JWT Bearer Authentication

**Frontend**
*   Angular
*   TypeScript
*   RxJS

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

*   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
*   [Node.js and npm](https://nodejs.org/en/)
*   [Angular CLI](https://angular.dev/tools/cli)
*   SQL Server (e.g., [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
*   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1.  **Clone the repository:**
    ```sh
    git clone https://github.com/riteshgtm/schoolmanagementsystem.git
    cd schoolmanagementsystem
    ```

2.  **Set up the Backend (API):**
    *   Navigate to the API project directory:
        ```sh
        cd SchoolManagementSystem.API
        ```
    *   Create or update `appsettings.Development.json` and add your SQL Server connection string:
        ```json
        {
          "ConnectionStrings": {
            "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SchoolDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
          }
        }
        ```
    *   Install the Entity Framework Core tools if you haven't already:
        ```sh
        dotnet tool install --global dotnet-ef
        ```
    *   Apply the database migrations to create the schema:
        ```sh
        dotnet ef database update
        ```
    *   Run the API. It will be available at `http://localhost:5085`.
        ```sh
        dotnet run
        ```

3.  **Set up the Frontend (UI):**
    *   In a new terminal, navigate to the UI project directory:
        ```sh
        cd SchoolManagementSystem.UI
        ```
    *   Install the required npm packages:
        ```sh
        npm install
        ```
    *   Run the Angular development server. The application will be available at `http://localhost:4200`.
        ```sh
        ng serve
        ```
    *   The UI is configured in `src/environments/environment.ts` to connect to the API at `http://localhost:5085/api`.


## API Endpoints

The following are the main endpoints provided by the `SchoolManagementSystem.API`.

### Auth Controller (`/api/auth`)

*   `POST /register` - Registers a new user.
*   `POST /login` - Authenticates a user and returns JWT access and refresh tokens.
*   `POST /refresh` - Generates a new access token using a valid refresh token.
*   `POST /revoke` - Revokes a user's refresh token.

### Student Controller (`/api/student`)
_Requires authentication for all endpoints._

*   `GET /` - Retrieves a list of all students.
*   `GET /{studentId}` - Retrieves a single student by their ID.
*   `POST /` - Adds a new student to the database.
*   `PUT /{studentId}` - Updates an existing student's information.
*   `DELETE /{studentId}` - Deletes a student. (Requires 'Admin' role).

### Person Controller (`/api/person`)

*   `GET /` - Retrieves a list of all people.
*   `GET /{personId}` - Retrieves a single person by their ID.
*   `POST /` - Adds a new person to the database.
*   `PUT /{personId}` - Updates an existing person's information.
*   `DELETE /{personId}` - Deletes a person.
