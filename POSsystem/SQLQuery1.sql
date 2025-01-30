CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL DEFAULT 0, -- Default stock is 0
    Price DECIMAL(10, 2) NOT NULL, -- Price with two decimal places
    CreatedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id), -- Foreign key to Products table
    Quantity INT NOT NULL, -- Quantity sold
    TotalPrice DECIMAL(10, 2) NOT NULL, -- Total price for the line item
    Date DATETIME DEFAULT GETDATE(), -- Date of sale
    CustomerId INT NULL FOREIGN KEY REFERENCES Customers(Id) -- Optional link to Customers table
);
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    Username NVARCHAR(50) NOT NULL UNIQUE, -- Unique username
    Password NVARCHAR(255) NOT NULL, -- Encrypted password
    Role NVARCHAR(50) NOT NULL DEFAULT 'User', -- Role (e.g., Admin, User)
    CreatedAt DATETIME DEFAULT GETDATE()
);
