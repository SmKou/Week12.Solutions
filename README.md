# Week 12 Solutions

By: Stella Marie

## Technologies Used

- C# 12
- ASP.NET Core 7
  - EntityFrameworkCore
  - Identity
  - MySQL

## Description

### ToDoList

Sample project for Week 12, adding authentication and authorization. Controller methods were adjusted for asynchronous user authentication and viewmodels were added to handle login and register.

### Library

Library is an MVC web app for managing books and user accounts. Books can be written by multiple contributors, among them the authors, and categories. A user can be a patron, librarian (high-auth admin), and author (low-auth admin), and can write recommendations which are not assumed to be either positive or negative. The main operations of the library can be found in the Checkout, Holdlist and Waitlist.

**Requirements**
- Librarian
  - Create, read, update, delete and list books in catalog (only if logged in)
  - Search for book by author|title
  - Enter multiple authors for book
  - See list of overdue books
- Patron
  - Checkout book (only if logged in)
  - Search for book => see how many copies available
  - History of books checked out
  - See checked out books due dates
- All users
  - Read books catalog

## Complete Setup

This app requires use of a database. It is suggested to use migrations for ensuring the smooth setup of Identity.

### Database Schemas

To setup the database, follow the directions in [Connecting the Database](#connecting-the-database) and then implement migrations as detailed in [Migrations](#migrations).

### Connecting the Database

In your IDE:
- Create a file in the root of an assembly: appsettings.json
  - Do not remove the mention of this file from .gitignore
- Add this code:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=[hostname];Port=[port_number];database=[database_name];uid=[username];pwd=[password]"
    }
}
```

Replace the values accordingly and brackets are not to be included.

### Migrations

- In the terminal, run ```dotnet build --project AssemblyName```
  - Or navigate into the assembly subdirectory of the project and run ```dotnet build```

This command will install the necessary dependencies. For it to work though, appsettings.json should already be setup. As migrations are included in the clone or fork, you should only need to run:

```dotnet ef database update```

However, since the models are already set up, if update does not work, then do:

```bash
dotnet ef migrations add Initial
dotnet ef database update
```

### Run the App

Once you have a database setup and the connection string included in the appsettings.json, you can run the app:

- Navigate to main page of repo
- Either fork or clone project to local directory
- Bash or Terminal: ```dotnet run --project AssemblyName```
  - If you navigate into the main assembly, use ```dotnet run```

If the app does not launch in the browser:
- Run the app
- Open a browser
- Enter the url: https://localhost:5001/

## Known Bugs

Please report any issues in using the app.

## License

[MIT](https://choosealicense.com/licenses/mit/)