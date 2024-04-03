# TrelloCloneProject

Welcome to the TrelloCloneProject! This project aims to replicate the core functionalities of Trello, providing a visual tool for task and project management. Before diving into the setup and running instructions, here's a brief overview of the technologies and patterns utilized in this project:

**Git:** Used for version control.

**.NET Core RESTful API:** Serves as the backend, providing a scalable and maintainable architecture.

**Repository Pattern:** Implements a separation between the data access logic and the business logic.

**EF Core:** Used as the Object-Relational Mapping (ORM) framework for .NET, simplifying data access.

**Automapper:** Facilitates the mapping between objects, reducing the amount of boilerplate code.

**JWT Auth:** Implements JSON Web Tokens for secure authentication.

**Json:** Used for data interchange between the server and client-side.

**Swagger:** Provides a user interface for testing and documenting the RESTful API.

**.NET MVC:** The architectural pattern used for the web application, separating the application into three main components: Model, View, and Controller.

**Bootstrap:** A front-end framework for developing responsive and mobile-first web pages.

**jQuery & Ajax:** Used for making asynchronous requests to the server without reloading the page.

**JS Drag & Drop:** Enhances the user interface, allowing users to drag and drop tasks across different stages.



**Getting Started:**
To get the TrelloCloneProject up and running on your local machine, follow these steps:



**Clone the repository:**
Use Git to clone the project to your local machine.



**Select Startup Projects:**
To successfully run the program, you need to select two startup projects in your development environment:


APILayer
TrelloClone.MVC
Static Login Credentials:
For initial testing and exploration, you can use the following static admin credentials:

Email: admin@gmail.com
Password: 12345

**Setup and Configuration:**
Please ensure that you have the latest versions of the required software and libraries installed on your system. Follow the documentation of each technology listed above for installation and configuration guides.

After cloning the project and setting up the environment, navigate to the project directory and restore the required NuGet packages for both the APILayer and TrelloClone.MVC projects. Also, ensure that the database connection strings in the configuration files are set up according to your local or development database server.

**Running the Application:**
With the projects configured as startup projects and dependencies resolved, you can now run the application. The API layer will start on its designated port, and the MVC layer will launch in your default web browser. You can use Swagger UI to explore and test the API endpoints.

Thank you for choosing TrelloCloneProject. I hope you find this project useful for your needs. Happy coding!
