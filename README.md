# Hair Salon Management App

*Epicodus C# Independent Project - Week 3 - June 9, 2017*

**By Joshua Fairchild**

---

## Description

This is an application

---

#### Basic Specifications

| Behavior | Example Input | Example Output |
|----------|---------------|----------------|
| User can view all stylists | *user navigates to index.cshtml* | All stylists are displayed in list format |  
| User can add a stylist | "John Smith, (123)-456-7890" | New stylist added: John Smith |  
| User can view the page for an individual stylist | *user clicks hyperlinked stylist name from index.cshtml* | All of the stylist's clients are displayed |
| User can delete all stylists | *user clicks "Remove all stylists" button* | Confirmation page is shown, allowing the user to delete all stylists or return to index |
| User can delete a single stylist | *user clicks "Delete stylist" button* | All stylists are displayed in list format |
| User can add a client, assigning them to a stylist | "Jenny, (123)-867-5309" | All of the stylist's clients are displayed |  
| User can delete all clients of a single stylist | *user clicks "Remove all clients" button* | Confirmation page is shown, allowing the user to delete all clients or return to stylist's page |  
| User can remove a single client from a stylist's list | *user clicks "Remove this client" button* | All of the stylist's clients are displayed |  
| User can update a clients information | "David Jones, (555)-987-1234" | Client information updated! Name: David Jones, Telephone: (555)-987-1234 |
| User can update a stylists information | "David Jones, (555)-987-1234" | Stylist information updated! |

----

#### Setup/Installation Requirements

*Note: You must be able to setup a Kestrel server, have the [Nancy](http://nancyfx.org/) web framework installed and have a C# compiler such as [Mono](http://www.mono-project.com/docs/getting-started/install/) to run this application*

* Clone this repository

 `git clone https://github.com/joshuafairchild1/hair_salon_csharp`

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


#### Legal

This software is licensed under the MIT license

Copyright (c) 2017 Joshua Fairchild
