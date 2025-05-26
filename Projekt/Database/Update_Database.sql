USE ExpensesManagerDB;
GO

IF NOT EXISTS (
    SELECT * 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Account' AND COLUMN_NAME = 'PhoneNumber'
)
BEGIN
    ALTER TABLE Account
    ADD PhoneNumber NVARCHAR(20) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME = 'PlannedTransactions'
)
BEGIN
    CREATE TABLE PlannedTransactions (
        PlannedTransactionID INT PRIMARY KEY IDENTITY(1,1),
        AccountID INT,
        CategoryID INT,
        Amount DECIMAL(10,2),
        PlannedDate DATE,
        Description NVARCHAR(255),
        FOREIGN KEY (AccountID) REFERENCES Account(AccountID) ON DELETE CASCADE,
        FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE
    );
END;
GO
