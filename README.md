# 💈 Men's Barber Shop - Windows Forms Application

This is a **Windows Forms Application** project built with **C#** for managing a **Men's Barber Shop** system. The application is structured around a simple user interface and uses **SQL Server** for data storage.

> ⚠️ Note: This project does not use object-oriented structures or custom classes. All logic is implemented within form code-behind.

---

## 🧾 Features

The application consists of the following main forms/pages:

### 1. 🔐 Login Page (Login Form)
- Allows users (e.g., admin) to log into the system.
- Credentials are verified from the SQL Server database.

### 2. 🏠 Main Dashboard (Main Form)
- The central interface after login.
- Provides navigation to other parts of the system like customer and buyer management.

### 3. 👨‍🦰 Customer Management Page (Person Form)
- Used to register and manage male customers.
- Add, edit, or delete customer information.
- Connected to SQL Server for storing client data.

### 4. 🛒 Purchase Page (Buyer Form)
- Allows adding and managing customer purchases.
- Tracks services or products purchased (like haircuts, shampoos, etc.)
- Integrated with SQL Server.

---

## 🛠️ Technologies Used

| Technology | Description |
|------------|-------------|
| `C#`       | Main programming language |
| `Windows Forms` | Desktop GUI framework |
| `SQL Server` | Backend database for storing user, customer, and purchase data |
| `ADO.NET` (likely) | Used for database connection and commands |

---

## 📦 Project Structure

```
📁 BarberShopApp/
├── LoginForm.cs
├── MainForm.cs
├── PersonForm.cs
├── BuyerForm.cs
├── Database.mdf (or external SQL DB)
├── Program.cs
└── App.config
```

---

## 🚀 How to Run

1. Clone the repository.
2. Open the project in **Visual Studio**.
3. Make sure **SQL Server** is running and connection strings are properly set.
4. Build and run the project (`F5`).

---

## 📌 Notes

- The project is **not object-oriented** (no custom classes).
- All logic resides within the Forms.
- It’s suitable for learning basic CRUD operations and connecting WinForms to SQL Server.

---

## ✍️ Author

**Belal Alhamid**  
📫 [GitHub Profile](https://github.com/Belal11132)  
🔐 Cybersecurity Enthusiast | C# Developer
