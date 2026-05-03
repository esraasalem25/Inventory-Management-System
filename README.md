📦 Inventory & Sales Management System (Console Application)
A sophisticated C# Console application built with a deep emphasis on Object-Oriented Programming (OOP) and Layered Architecture. This system manages product inventories, handles complex sales transactions, and generates detailed business reports.

🏛️ Architecture & Design Patterns
The project is organized into logical namespaces to ensure the Single Responsibility Principle (SRP):

Inventory.Classes: Contains core entities (Product, Supplier, Transaction).

Inventory.Services: Dedicated logic for ReportsManager, DiscountManager, and SalesManager.

Inventory.Enums: Centralized categories for better data consistency.

File Management: Persistent storage using a custom FileManager to Load/Save data via text files.

🚀 Advanced Technical Features
1. Sales & Discount Logic
Dynamic Discounting: A dedicated DiscountManager that applies tiered discounts based on quantity (e.g., 20% for 10+ units) and specific categories (e.g., Food/Beverages).

Transaction Tracking: Every sale generates a unique Transaction object with an auto-incrementing ID and timestamps.

2. Robust Inventory Operations
Encapsulation: Using private fields and controlled access via methods like AddStock and RemoveStock.

Method Overloading: The Inventoryy class features overloaded methods to search or remove products by ID, Name, or Object.

Error Handling: Built-in checks for stock availability, negative inputs, and non-existent IDs.

3. Supplier & Reports Management
Supplier Relationship: Managing multiple products per supplier with validation to prevent duplicate entries.

Detailed Reporting: The ReportsManager provides insights into:

Best-selling products.

Total sales and estimated profit.

Low Stock Alerts: Identifies items below a certain threshold to trigger reordering.

4. Data Persistence
File I/O: Custom implementation to parse and save system state into flat files, ensuring data isn't lost when the application closes.

🛠️ Tech Stack & Skills
Language: C# (.NET Core)

OOP Concepts: Inheritance, Encapsulation, Polymorphism, and Abstraction.

Data Structures: Extensive use of Lists, Dictionaries, and Enums.

LINQ-style Logic: Efficient searching and filtering across collections.

📂 How it Works
Load: The FileManager reads products.txt to initialize the inventory.

Interact: Users use a numerical menu to manage stock or make sales.

Analyze: The system calculates real-time totals and updates the inventory state immediately.
