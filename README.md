Themed E-Commerce Website using Angular and ASP.NET Core 8
Project Overview
This project was developed during my one-month internship at ABB. It is a full-stack e-commerce web application built with Angular for the frontend and ASP.NET Core 8 for the backend. The application includes dynamic theming, user authentication, password recovery via email, and product cart management.

Features
Frontend (Angular)
Theme switcher (Light and Dark mode)

User authentication:

Login

Signup

Forgot Password

Product cart functionality

Responsive and user-friendly interface

Backend (ASP.NET Core 8)
User data management using a secure database

Login and signup API endpoints

Password recovery using SMTP to send the password to the user's registered email

RESTful APIs for frontend-backend communication

Integration with SQL Server (or any other relational database)

Technologies Used
Component	Technology
Frontend	Angular
Backend	ASP.NET Core 8
Database	SQL Server
Email Service	SMTP (System.Net.Mail)
Version Control	Git and GitHub

Getting Started
Prerequisites
.NET 8 SDK

Node.js and npm

Angular CLI

SQL Server (or another database)

Frontend Setup
Navigate to the frontend project folder:

bash
Copy
Edit
cd your-angular-folder
Install dependencies:

nginx
Copy
Edit
npm install
Run the Angular development server:

nginx
Copy
Edit
ng serve
Backend Setup
Navigate to the backend project folder:

bash
Copy
Edit
cd your-backend-folder
Restore and build the project:

nginx
Copy
Edit
dotnet restore
dotnet build
Run the ASP.NET Core application:

arduino
Copy
Edit
dotnet run
Update the appsettings.json file with:

Database connection string

SMTP configuration (host, port, sender email, credentials)

How It Works
Users can register and log in securely.

If a user forgets their password, the backend sends the password to their email using the configured SMTP server.

The frontend supports switching between light and dark themes.

Users can add and manage products in the cart.

Future Enhancements
Secure password reset links with tokens instead of plain-text passwords

JWT-based authentication and role-based access

Integration of payment gateways

Order history, product ratings, and admin dashboard features

License
This project is developed for academic and demonstration purposes during my internship at ABB.











