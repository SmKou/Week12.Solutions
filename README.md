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