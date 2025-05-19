# Auflistung aller Datentypen
## Account
- **AccountID:**     PRIMARY KEY INT(1,1)
- **FirstName:**     NVARCHAR(50)
- **LastName:**      NVARCHAR(50)
- **Email:**         NVARCHAR(255)
- **Password:**      NVARCHAR(255)
- **MonthlyIncome:** DECIMAL(10, 2)
## Transaction
- **TransactionID:** PRIMARY KEY INT(1,1)
- **Amount:** DECIMAL(10,2)
- **Date:** DATE
- **Description:** VARCHAR(255)
## Budget
- **BudgetID:** PRIMARY KEY INT(1,1)
- **Amount:** DECIMAL(10,2)
- **Month:** NVARCHAR(20)
## Category
- **CategoryID:** PRIMARY KEY INT
- **Name:** NVARCHAR(100)
- **Description:** NVARCHAR(255)
