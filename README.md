# Webapp with Service Oriented Architecture

## Overview

The program is developed in C#, utilizing the .NET 6 Web API template. The solution is structured into four distinct projects:

- **WebApi**: Acts as the startup project. It includes the `Program.cs` file, which is the entry point of the project, along with all controllers and mapping profiles.
- **Common**: Contains all shared code used across other projects.
- **Services**: Houses all the service logic.
- **DB**: Comprises all database entities, migrations, and repositories.

To improve usability, Swagger has been integrated, providing a convenient interface to visualize and test the project's endpoints. The database is powered by MariaDB version 10.6 and is deployed using Docker, facilitating an efficient setup.

## Getting Started

### Prerequisites

- .NET 6 SDK
- Docker
- Visual Studio 2022 or later

### Setting Up the Environment

1. **Database Setup with Docker Compose**: Use the following `docker-compose.yaml` file to set up the MariaDB database:
   
  ```yaml
version: '3.8'

services:
  mariadb:
    image: mariadb:10.6
    container_name: mariadb-container
    environment:
      MYSQL_ROOT_PASSWORD: sqlpass1234
      MYSQL_DATABASE: SoftwareEngineerDb
    ports:
      - "3309:3306"
    volumes:
      - mariadb_data_se:/var/lib/mysql

volumes:
  mariadb_data_se:
  ```

Save this file as docker-compose.yaml in your project directory, and then run:

```bash
docker-compose up -d
```

### Running Migrations

1. **Open Visual Studio**: Launch Visual Studio 2022 and open the solution file.
2. **Apply Migrations**: Before running the application, apply the existing EF Core migrations to set up your database schema. This can be done using the Package Manager Console within Visual Studio, selecting **DB** project (since this contains all the migrations in it) and by running:

    ```bash
    update-database
    ```

    Alternatively, you can use the .NET CLI:

    ```bash
    dotnet ef database update
    ```

### Starting the Application

1. **Debug Mode**: Press `F5` in Visual Studio to start the application with debugging.
2. **Release Mode**: Use `Ctrl+F5` to start without debugging.

The application will launch in your default web browser, and you should be able to interact with the API through Swagger.

By following these steps, you should have a running instance of the Service Oriented Architecture application, ready for development and testing.

# MultyServiceArchitecture
