# RegistrationApp

This workspace contains a .NET 8 MVC app `RegistrationApp` with a registration form and EF Core integration.

To run the app from the workspace root (Windows PowerShell):

```powershell
cd "C:\Users\anji1\MVC FORM PROJ"
.\run-registration.ps1
```

Alternatively run directly from the project folder:

```powershell
cd "C:\Users\anji1\MVC FORM PROJ\RegistrationApp"
dotnet run
```

Database: the app writes to SQL Server using the connection in `appsettings.Development.json` (DefaultConnection -> `.\SQLEXPRESS`). If you don't have SQL Server Express installed, the project also falls back to SQLite using `Registration.db`.
