# UML Class Diagram für Expensemanager

## Klassen und Attribute

### User
```plaintext
+-------------------+
|     User          |
+-------------------+
| - AccountID: int  |
| - FirstName: str  |
| - LastName: str   |
| - Email: str      |
| - Password: str   |
| - MonthlyIncome: float |
+-------------------+
| + Register()      |
| + Login()         |
| + UpdateProfile() |
+-------------------+
```

### Transaction
```
+-------------------+
|  Transaction      |
+-------------------+
| - TransactionID: int |
| - Amount: float   |
| - Date: DateTime  |
| - Description: str|
| - Category: str   |
+-------------------+
| + AddTransaction()|
| + EditTransaction()|
| + DeleteTransaction()|
+-------------------+
```
### Budget
```
+-------------------+
|     Budget        |
+-------------------+
| - Category: str   |
| - Limit: float    |
| - CurrentSpending: float |
+-------------------+
| + SetBudget()     |
| + CheckBudget()   |
| + GetWarning()    |
+-------------------+
```
### Statistics
```
+-------------------+
|   Statistics      |
+-------------------+
| - Reports: list   |
| - Charts: list    |
+-------------------+
| + GenerateReport()|
| + ExportReport()  |
| + DisplayCharts() |
+-------------------+
```
### Database
```
+-------------------+
|   Database        |
+-------------------+
| - Connection: SQLiteConnection |
+-------------------+
| + Connect()       |
| + Disconnect()    |
| + ExecuteQuery()  |
+-------------------+
```

## Beziehungen

- **User** hat eine 1:n-Beziehung mit **Transaction** (ein Benutzer kann mehrere Transaktionen haben).
- **User** hat eine 1:n-Beziehung mit **Budget** (ein Benutzer kann mehrere Budgets haben).
- **Transaction** hat eine 1:1-Beziehung mit **Budget** (jede Transaktion kann einer Budgetkategorie zugewiesen werden).
- **Statistics** nutzt Daten aus **Transaction** und **Budget**, um Berichte und Diagramme zu erstellen.
- **Database** verwaltet die Speicherung und Abfrage von Daten für **User**, **Transaction** und **Budget**.

## Erläuterung

- **User**: Verwaltet Benutzerinformationen und Authentifizierung.
- **Transaction**: Repräsentiert die Ausgaben und Einnahmen des Benutzers.
- **Budget**: Verwaltet Budgets für verschiedene Kategorien.
- **Statistics**: Erstellt Berichte und Diagramme basierend auf Transaktionen und Budgets.
- **Database**: Führt Datenbankoperationen mit SQLite durch.
