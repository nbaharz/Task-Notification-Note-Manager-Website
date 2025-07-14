# ABOARD: Task, Notification & Note Manager Website

## Definition and Aim of The Project
The goal of this project is to create a rich web application that includes time management, task planning, note-taking, notification management, and personal tracking.

The main features of the website are taking short daily notes, creating to-do lists, and setting reminders for events, appointments, or tasks. These properties are designed to help individuals manage both their personal and professional lives in a more organized and structured manner.

In addition, a module external services has been developed to combine users' search and monitoring activities performed on different platforms into a single interface. Thanks to this component, users can directly monitor data from various services within the system. Currently, the ability to send notifications to users when user-selected products are discounted on Amazon has been added. This allows users to keep informed about price changes in the products they are interested in without having to manually check.

The external services infrastructure will be expanded in the future with new external integrations such as NewsAPI and Gmail. This would enable consumers to access a broader range of information, such as news updates and particular email notifications, via a single, consolidated platform.

## Backend Architecture 
“The structure and design of software that operates and handles the backend logic on the server-side of a website is backend architecture.”. Mainly a backend architecture is a way of designing your backend software and how it is coded and structured to deal with the incoming requests and front ends. The onion architecture was selected for this project since it is frequently utilized in practical applications. The onion architecture was chosen for this project due to its common application in real-world situations. This software architecture aims to maintain low dependencies, enhance testability, and improve maintainability throughout development. It enables effective and sustainable product development by allowing the integration of new features without affecting existing components. Below is a definition of the layer structure of the onion architecture.
- **Domain Layer:** Contains core business entities and repository interfaces.  
- **Application Layer:** Manages the application's behavior and includes service interfaces, dependency injection logic, and DTOs.  
- **Infrastructure Layer:** Handles communication with external APIs and background services.  
- **Persistence Layer:** Manages database operations, context configuration, and migrations.  
- **API Layer:** Provides HTTP endpoints via controllers.

This layered architecture guarantees flexibility and security by separating the responsibilities of each layer and limiting the communication between neighboring layers. Reformation works this way: the application layer refers to the domain layer to access core entities and repository abstractions, the API layer refers to the application layer to access business logic, and the Infrastructure and Persistence levels carry out the interfaces specified in the domain layer. The fundamental logic of the Onion architecture is protecting the current structure from external changes and possible security flaws by the strict dependency aspect. Separating these architectural roles and following a clear reference to the structure, improves system security, sustainability, and testability [2]. 


The application layer of onion architecture uses the Core layer, which manages database operations and follows the generic design pattern. This generic pattern aims to reduce code repetition by centralizing database operations with a single procedure that fits every database object. Optionally, it automatically determines the required database table and allows several actions to be performed efficiently from one place.
In addition, all database operations (CRUD) are abstracted using the Interface Segregation Policy for each class in accordance with SOLID principles. This solution ensures the scalability and sustainability of the software by making it easier to introduce future methods specific to certain tables.


