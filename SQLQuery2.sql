CREATE TABLE Products (
    ProductId INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(100),
    Price DECIMAL(18,2),
    Quantity INT
);