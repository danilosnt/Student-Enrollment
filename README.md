# 📋 Student Enrollment System

A web application for student management, developed in ASP.NET Core MVC.

This project implements a complete CRUD (Create, Read, Update, Delete) system, focusing on robust data validation, MVC architecture best practices, and a modern, interactive user interface.

---

## 📂 Repository Structure

This repository is organized into two main folders, each containing a complete, independent version of the project:

### 1. ➡️ `/Portuguese`
A full version of the project with all source code, comments, and user interface in **Portuguese (Brazil)**.
* **To open:** Use the `CadastroDeEstudantes.sln` file inside this folder.

### 2. ➡️ `/English`
A refactored version of the project with all source code, comments, and user interface in **English**.
* **To open:** Use the `StudentEnrollment.sln` file inside this folder.

---

## 💻 Technologies (Used in both versions)

### Back-end
* **C# 12** and **.NET 8**
* **ASP.NET Core MVC**: Main framework for the web application.
* **Entity Framework Core 8**: ORM for data access (Code-First approach).

### Front-end
* **HTML5, CSS3, JavaScript**
* **Bootstrap 5**: Framework for styling and responsiveness.
* **jQuery** & **Toastr.js**: Libraries for interactivity (CPF mask and notifications).

### Database & Tools
* **SQL Server LocalDB**
* **Visual Studio 2022**

---

## Main Features (Present in both versions)

* **Complete CRUD Management:** Full system to Create, Read, Update, and Delete students.
* **Dynamic Search:** A real-time search field to filter the student list by Name, CPF, or Address.
* **Robust Validations:**
    * **CPF:** Mathematical validation, database uniqueness (Unique Index), and format mask.
    * **Name:** Allows only letters and spaces.
    * **Completion Date:** Restricted to the period between 1900 and the current date.
* **Modern UI:** Responsive layout using "Cards" and user feedback with "Toast" notifications.
* **Security:** CSRF (Anti-Forgery Tokens) protection and a delete confirmation system.

---

## 📂 Project Structure (Internal Architecture)

Both versions (`/Portuguese` and `/English`) follow the standard ASP.NET Core MVC architecture, with responsibilities separated as follows:

* **/Controllers**: Receive user requests, process business logic, and return the appropriate `View` (e.g., `EstudantesController.cs` / `StudentsController.cs`).
* **/Models**: Define the data entities (e.g., `Estudante.cs` / `Student.cs`) and their validation rules.
* **/Views**: Contain the `.cshtml` files that define the user interface (the screens), including folders for `Estudantes` (or `Students`), `Home`, and `Shared`.
* **/Data**: Manage the database configuration and communication via Entity Framework (e.g., `ApplicationDbContext.cs`).
* **/Validation**: Contain custom validation attribute classes for specific business rules (e.g., `CpfValidationAttribute.cs`).
* **/wwwroot**: Stores all static front-end assets that are sent directly to the user's browser, such as CSS (`site.css`), JavaScript, and libraries.

---

## 🛠️ How to Run Locally

You can run either version of the project.

**Prerequisites:**
* .NET 8 SDK
* Visual Studio 2022 (with the "ASP.NET and web development" workload).

**Steps:**
1.  Clone the repository:
    ```bash
    git clone [https://github.com/danilosnt/Student-Enrollment.git](https://github.com/danilosnt/Student-Enrollment.git)
    ```
2.  **Choose a version** and open the corresponding solution in Visual Studio:

    * **For the Portuguese version:**
        * Open the file `Student-Enrollment/Português/CadastroDeEstudantes.sln`

    * **For the English version:**
        * Open the file `Student-Enrollment/English/StudentEnrollment.sln`

3.  **Create the Database:**
    * With the solution open, go to the menu **Tools > NuGet Package Manager > Package Manager Console**.
    * Run the following command to create the database for that version:
    ```powershell
    Update-Database
    ```
4.  **Run the Application:**
    * Press **`F5`** to start the project.
