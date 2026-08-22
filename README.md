# Task Management System

A simple and professional web application for creating, organizing, managing, and tracking daily tasks efficiently.

## 📌 About The Project

The Task Management System is a web-based application designed to help users manage their daily tasks in an organized and efficient way.

Users can create new tasks, view task details, update existing tasks, search for tasks, and delete tasks. The system also provides a dashboard that displays task statistics based on their current status.

## ✨ Features

- 🔐 User Login and Authentication
- 🏠 Dashboard with task statistics
- ➕ Create new tasks
- ✏️ Edit existing tasks
- 🔍 Search for tasks
- 📋 View all tasks
- 📄 View task details
- 🗑️ Delete tasks
- 📊 Track task status
- ⭐ Set task priority
- 📅 Set task due dates

## 🛠️ Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- HTML
- CSS
- Bootstrap
- Razor Views
- Visual Studio

## 📸 Screenshots

### 🏠 Home / Dashboard

The dashboard provides an overview of the user's tasks and displays the total number of tasks according to their status.

![Home Dashboard](image/home.png)

---

### 📋 My Tasks

The My Tasks page allows users to view, search, edit, view details, and delete their tasks.

![My Tasks](image/tasks.png)

---

### ➕ Create Task

The Create Task page allows users to add a new task by entering the title, description, status, priority, and due date.

![Create Task](image/create-task.png)

---

### 📄 Task Details

The Task Details page displays complete information about a selected task, including its title, description, status, priority, due date, and creation date.

![Task Details](image/task-details.png)

---

## 📂 Project Structure

```text
Task-Management-System
│
├── TaskManager
│   ├── Controllers
│   ├── Models
│   ├── Views
│   ├── Data
│   └── wwwroot
│
├── image
│   ├── home.png
│   ├── tasks.png
│   ├── create-task.png
│   └── task-details.png
│
├── .gitignore
├── TaskManager.sln
└── README.md
