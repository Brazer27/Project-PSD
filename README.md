# GymMe Project

GymMe - Supplement Selling Application
GymMe is a web-based health and supplement-selling application designed for fitness enthusiasts and store admins. This project is developed as part of the Pattern Software Design course and demonstrates the use of ASP.NET with Domain-Driven Design (DDD) principles.

Features
- View Layer: User interface layer responsible for displaying information and interpreting commands.
- Controller Layer: Validates user input and delegates requests to the lower layers for further processing.
- Handler Layer: Implements business logic and manages interactions between the controller and the repository.
- Repository Layer: Encapsulates database access, manages domain objects, and provides methods for CRUD operations.
- Factory Layer: Handles complex object creation, ensuring consistency in the creation of aggregate objects.
- Model Layer: Represents the business concepts using Entity Framework to interact with the database.

This project follows Domain-Driven Design (DDD) methodology and provides an optional web service layer. The goal is to showcase a clean architecture and efficient separation of concerns, ensuring scalability and maintainability.

Technologies Used:
- ASP.NET Core
- Entity Framework
- Domain-Driven Design (DDD)
- SQL Database
