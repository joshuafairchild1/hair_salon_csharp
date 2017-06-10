# Hair Salon Management App

*Epicodus C# Independent Project - Week 3 - June 9, 2017*

**By Joshua Fairchild**

---

## Description

This application demonstrates my ability to create a project that will interact with a database using object oriented C# and SQL. The user is able to create new stylists, adding them to a list of employees, and to create new clients by assigning them to a stylist in a one-to-many relationship.

The user is able to interact with the information they enter in several ways. All stylists can be viewed from the index page, and clicking on a stylist's name will display their name, phone number, and all clients. Stylists as well as clients may have their existing information updated by the user, or they can be deleted altogether. The user is able to delete information in several ways: deleting an individual stylist, deleting all stylists, deleting all clients of a given stylist, or deleting a single client. The application also contains a search function, allowing the user to lookup stylists by name.

---

#### Basic Specifications

| Behavior | Example Input | Example Output |
|----------|---------------|----------------|
| User can view all stylists | *user navigates to index.cshtml* | All stylists are displayed in list format |  
| User can add a stylist | "John Smith, (123)-456-7890" | All stylists are displayed in list format |  
| User can view the page for an individual stylist | *user clicks hyperlinked stylist name from index.cshtml/result.cshtml* | All of the stylist's clients are displayed, as well as stylist info |
| User can delete all stylists | *user clicks "Delete all stylists" button* | Confirmation page is shown, allowing the user to delete all stylists or return to index |
| User can delete a single stylist | *user clicks "Delete this stylist" button* | All stylists are displayed in list format |
| User can add a client, assigning them to a stylist | "Jenny, (123)-867-5309" | All of the stylist's clients are displayed |  
| User can delete all clients of a single stylist | *user clicks "Delete this stylist's clients" button* | Stylist's page is displayed with no clients |  
| User can remove a single client from a stylist's list | *user clicks "Delete" button* | All of the stylist's clients are displayed |  
| User can update a clients information | "John Locke, (555)-987-1234" | All of the stylist's clients are displayed, including changes |
| User can update a stylists information | "Sam Green, (555)-987-1234" | All of the stylist's clients are displayed, including changes |
| User can look up stylists by name | "John Smith" | Results page is shown, displaying all stylist matches (or none if no matches) with hyperlinks to their page |

----

#### Setup/Installation Requirements

* Install [Mono](http://www.mono-project.com/docs/getting-started/install/) or another C# compiler.

* Install the [Nancy](http://nancyfx.org/) web framework.

* Install the ASP.NET CORE framework for access to the Kestrel server

* Clone this repository

  `git clone https://github.com/joshuafairchild1/hair_salon_csharp`

* In PowerShell, run the following commands:

  `SQLCMD -S "(localdb)\mssqllocaldb"`

  `CREATE DATABASE hair_salon;`

  `GO;`

  `USE hair_salon;`

  `GO;`

  `CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), telephone VARCHAR(255));`

  `GO;`

  `CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), telephone VARCHAR(255), stylist_id INT);`

  `GO;`

* Navigate to the root directory and run `dnx kestrel` to start the server

* Navigate to `localhost:5004` in your web browser to view the application



#### Known Bugs/Issues
* None known


#### Technologies Used
* Nancy web framework
* Razor C# syntax
* C#
* HTML
* CSS (Bootstrap)
* Kestrel web server
* xUnit
* SQL
* Microsoft SQL Server Management Studio


#### Legal

This software is licensed under the MIT license

Copyright (c) 2017 Joshua Fairchild
