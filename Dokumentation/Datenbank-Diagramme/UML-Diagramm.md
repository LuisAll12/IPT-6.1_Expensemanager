# UML Class Diagram – Expense Manager

##  User

### Attributes

| Name         | Type   | Description                      |
|--------------|--------|----------------------------------|
| AccountID    | int    | Unique user ID                   |
| FirstName    | string | User's first name                |
| LastName     | string | User's last name                 |
| Email        | string | User's email address             |
| Password     | string | User's password (stored securely)|
| MonthlyIncome| float  | Monthly income of the user       |

### Methods

| Method         | Description                    |
|----------------|--------------------------------|
| Register()     | Registers a new user           |
| Login()        | Authenticates an existing user |
| UpdateProfile()| Updates user profile info      |

---

##  Transaction

### Attributes

| Name          | Type      | Description                            |
|---------------|-----------|----------------------------------------|
| TransactionID | int       | Unique ID of the transaction           |
| Amount        | float     | Transaction amount                     |
| Date          | DateTime  | Date of the transaction                |
| Description   | string    | Optional note or label                 |
| Category      | string    | Type of transaction (e.g., food, rent) |

### Methods

| Method             | Description                        |
|--------------------|------------------------------------|
| AddTransaction()   | Adds a new transaction             |
| EditTransaction()  | Edits an existing transaction      |
| DeleteTransaction()| Deletes a transaction              |

---

##  Budget

### Attributes

| Name            | Type   | Description                                |
|-----------------|--------|--------------------------------------------|
| Category        | string | Budget category (e.g., groceries, rent)     |
| Limit           | float  | Maximum allowed spending                   |
| CurrentSpending | float  | Current amount spent in this category      |

### Methods

| Method         | Description                               |
|----------------|-------------------------------------------|
| SetBudget()    | Defines or updates a budget category      |
| CheckBudget()  | Compares spending with budget limit       |
| GetWarning()   | Warns if budget threshold is exceeded     |

---

##  Statistics

### Attributes

| Name    | Type | Description                      |
|---------|------|----------------------------------|
| Reports | list | List of generated reports        |
| Charts  | list | Visual chart data from analysis  |

### Methods

| Method            | Description                         |
|-------------------|-------------------------------------|
| GenerateReport()  | Generates a spending report         |
| ExportReport()    | Exports report to file              |
| DisplayCharts()   | Displays spending in chart form     |

---

##  Database

### Attributes

| Name       | Type              | Description                          |
|------------|-------------------|--------------------------------------|
| Connection | SQLiteConnection  | Active connection to SQLite database |

### Methods

| Method         | Description                             |
|----------------|-----------------------------------------|
| Connect()      | Establishes connection to the database  |
| Disconnect()   | Closes the database connection          |
| ExecuteQuery() | Executes a database SQL query           |

---

##  Relationships

| From Class   | Relationship | To Class     | Description                                            |
|--------------|--------------|--------------|--------------------------------------------------------|
| User         | 1 → *        | Transaction  | A user can have multiple transactions                  |
| User         | 1 → *        | Budget       | A user can define multiple budgets                     |
| Transaction  | 1 → 1        | Budget       | A transaction is associated with one budget category   |
| Statistics   | uses         | Transaction  | Statistics gathers data from transactions              |
| Statistics   | uses         | Budget       | Statistics uses budget data                            |
| Database     | manages      | User         | Database stores user data                              |
| Database     | manages      | Transaction  | Database stores transactions                           |
| Database     | manages      | Budget       | Database stores budget information                     |
