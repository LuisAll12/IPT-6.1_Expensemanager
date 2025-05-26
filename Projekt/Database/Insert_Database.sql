USE ExpensesManagerDB;
GO

INSERT INTO Account (FirstName, LastName, Email, Password, MonthlyIncome)
VALUES 
('Max', 'Mustermann', 'max@example.com', 'hashed_password_123', 3500.00);
GO

INSERT INTO Category (Name, Description)
VALUES 
('Lebensmittel', 'Ausgaben für Essen und Trinken'),
('Miete', 'Monatliche Mietkosten'),
('Transport', 'Ausgaben für Verkehrsmittel'),
('Freizeit', 'Ausgaben für Hobbys und Unterhaltung');
GO

INSERT INTO Budget (AccountID, Amount, Month)
SELECT AccountID, 2000.00, 'Mai 2025' 
FROM Account WHERE Email = 'max@example.com';
GO

INSERT INTO Transactions (AccountID, CategoryID, Amount, Date, Description)
SELECT A.AccountID, C.CategoryID, 50.00, GETDATE(), 'Wocheneinkauf im Supermarkt'
FROM Account A
JOIN Category C ON C.Name = 'Lebensmittel'
WHERE A.Email = 'max@example.com';

INSERT INTO Transactions (AccountID, CategoryID, Amount, Date, Description)
SELECT A.AccountID, C.CategoryID, 900.00, GETDATE(), 'Monatliche Miete'
FROM Account A
JOIN Category C ON C.Name = 'Miete'
WHERE A.Email = 'max@example.com';
GO