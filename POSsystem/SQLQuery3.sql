CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    Username NVARCHAR(50) NOT NULL UNIQUE, -- Unique username
    Password NVARCHAR(255) NOT NULL, -- Encrypted password
    Role NVARCHAR(50) NOT NULL DEFAULT 'User', -- Role (e.g., Admin, User)
    CreatedAt DATETIME DEFAULT GETDATE()
);
