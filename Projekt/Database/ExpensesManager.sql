use master
go
drop database if exists ExpensesManagerDB;
go
create database ExpensesManagerDB;
go

use ExpensesManagerDB;

-- Account table
CREATE TABLE Account (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    MonthlyIncome DECIMAL(10, 2)
);

-- Budget table
CREATE TABLE Budget (
    BudgetID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT,
    Amount DECIMAL(10, 2),
    Month NVARCHAR(20),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID) ON DELETE CASCADE
);

-- Category table
CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255)
);

-- Transaction table
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT,
    CategoryID INT,
    Amount DECIMAL(10, 2),
    Date DATE,
    Description NVARCHAR(255),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID) ON DELETE CASCADE,
    Foreign KEY (CategoryID) REFERENCES Category(CategoryID)  ON DELETE CASCADE
);


