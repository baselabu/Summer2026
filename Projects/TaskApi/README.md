# TaskApi

TaskApi is a .NET 10 ASP.NET Core Web API for managing tasks with JWT authentication and a SQLite-backed data store.

This README was AI-generated to help document the project quickly and clearly.

## Features

- JWT-based authentication for protected task routes
- Task CRUD endpoints
- User registration and login endpoints
- Entity Framework Core with SQLite
- OpenAPI support in development
- Centralized exception handling and basic request logging

## Requirements

- .NET 10 SDK
- SQLite is included through Entity Framework Core, no separate server is required

## Configuration

The application reads JWT settings from [appsettings.json](appsettings.json):

- `Jwt:Key`
- `Jwt:Issuer`
- `Jwt:Audience`

The app uses a local SQLite database file named `tasks.db`.

## Run The API

```bash
dotnet restore
dotnet run
```

In development, the app exposes OpenAPI automatically. If you want to use `dotnet watch` on Linux, set `DOTNET_USE_POLLING_FILE_WATCHER=1` in your terminal environment.

## API Endpoints

### Authentication

- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Log in and receive a JWT token

### Tasks

All task routes require authorization.

- `GET /tasks` - Get all tasks
- `GET /tasks/{id}` - Get a task by ID
- `POST /tasks` - Create a task
- `PATCH /tasks/{id}` - Update a task
- `DELETE /tasks/{id}` - Delete a task

## Example Flow

1. Register a user with `POST /api/auth/register`.
2. Log in with `POST /api/auth/login`.
3. Copy the returned JWT token.
4. Send the token as a Bearer token when calling the `/tasks` endpoints.

## Project Structure

- `Controllers/` - API controllers
- `Data/` - Entity Framework DbContext
- `DTOs/` - Request payload models
- `Models/` - Domain entities
- `Services/` - Business logic and token handling
- `interfaces/` - Service and repository contracts

## Notes

- The application returns structured JSON error responses for common validation and not-found cases.
- Database schema changes are managed through the migrations in `Migrations/`.