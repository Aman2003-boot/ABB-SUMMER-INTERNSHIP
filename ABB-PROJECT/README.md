<<<<<<< HEAD
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











=======
# ABBPROJECT

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.2.12.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
>>>>>>> 06fa331 (initial commit)
