# Employee Management System

An advanced system designed to streamline the process of managing employees within an organization. This system allows for efficient handling of employee details, department assignments, club memberships, and more, with a focus on flexibility and ease of use.

## Overview

The Employee Management System is built to cater to the needs of HR departments and managers who require a robust solution for overseeing their workforce. It features a modular design, allowing for easy expansion and customization.

## Features

- **Employee Management**: Add, update, and remove employees.
- **Department Handling**: Assign employees to departments, manage department details.
- **Club Membership**: Manage club memberships for employees, including special rules for board members.
- **Vacation Management**: Handle vacation requests and automatically enforce policies based on employee status.
- **Performance Tracking**: Monitor salesperson performance against targets.
- **Event-Driven Notifications**: Automated notifications for significant employee lifecycle events.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 or a compatible IDE that supports .NET 6.0

### Installation

1. Clone the repository to your local machine using Git.
2. Open the solution file (`EmployeeManagementSystem.sln`) in Visual Studio.
3. Restore the NuGet packages.
4. Build the solution.

## Key Scripts

### [Program.cs](#program.cs-context)

The entry point of the application. Initializes the application and sets up the main loop.

### [Enum.cs](#enum.cs-context)

Defines the `LayOffCause` enum, which lists possible reasons for an employee layoff.

### [Generic.cs](#generic.cs-context)

Contains utility methods for operations like adding entities, checking quotas, and displaying information. It acts as a helper class for managing departments and clubs.

### [Club.cs](#club.cs-context)

Defines the `Club` class, responsible for managing club members, including adding and removing members based on specific criteria.

### [Department.cs](#department.cs-context)

Defines the `Department` class, responsible for managing department staff, including adding and removing staff based on specific criteria.

### [Employee.cs](#employee.cs-context)

The base class for all employees, containing common properties and methods like ID, age, vacation stock, and the ability to request vacations.

### [EmployeeLayOffEventArgs.cs](#employeelayoffeventargs.cs-context)

Defines the `EmployeeLayOffEventArgs` class, which is used to pass data during employee layoff events.

### [BoardMember.cs](#boardmember.cs-context)

Defines the `BoardMember` class, a specific type of employee with unique behaviors for requesting vacations and resigning.

### [SalesPerson.cs](#salesperson.cs-context)

Defines the `SalesPerson` class, a specific type of employee with a focus on sales targets and quotas.

## Running the Tests

To run the automated tests for this system, use the following command.

### Break down into end-to-end tests

These tests cover the entire application flow, ensuring that all components work together as expected. For example, adding an employee and assigning them to a department and club.

### And coding style tests

Coding style tests ensure that the codebase maintains a consistent style, adhering to .NET coding conventions.

## Deployment

To deploy this project on a live system, ensure that the target environment meets the prerequisites and follow the steps in the Installation section.

## Contributing

Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
