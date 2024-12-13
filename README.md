This is a .NET-based solution that uitlizes a marvel heroes API to synchronize data and store it in a SQL database. The project includes:

- A **WebAPI** to expose and consume data.
- A **WorkerService** to periodically synch data using Hangfire.

---

### **Prerequisites**
Ensure to have the following installed:

1. [SQL server] Installed locally or accessible.
2. [.NET SDK] (https://dotnet.microsoft.com/download/dotnet)

---

## **Setup**

### 1. Configure the ConnectionString
1. Open the `appsettings.json` file located in the WorkerService project.
2. Replace `DefaultConnection` inside `ConnectionStrings` with your SQL server connection string.


### 2. Create the database and apply migrations
1. If the database does not exist in SQL server, create it manually or use:
    ```sql
    CREATE DATABASE DATABASE_NAME
    ```

2. Open the terminal inside the solution path and run the following commands:
   ```bash
   dotnet ef database update --project Infrastructure --startup-project WebApi
   ```


Ensure to have SQL server running before starting the project.