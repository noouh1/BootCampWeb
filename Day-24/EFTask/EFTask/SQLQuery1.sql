-- 1. Create Tables
CREATE TABLE Category (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Product (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Category(CategoryId)
);
GO
-- 2. Stored Procedures
-- Category CRUD
CREATE PROCEDURE sp_InsertCategory
    @CategoryName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Category (CategoryName)
    VALUES (@CategoryName);
END
GO

CREATE PROCEDURE sp_UpdateCategory
    @CategoryId INT,
    @CategoryName NVARCHAR(100)
AS
BEGIN
    UPDATE Category
    SET CategoryName = @CategoryName
    WHERE CategoryId = @CategoryId;
END
GO

CREATE PROCEDURE sp_DeleteCategory
    @CategoryId INT
AS
BEGIN
    DELETE FROM Category WHERE CategoryId = @CategoryId;
END
GO


CREATE PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT * FROM Category;
END
GO

-- Product CRUD
CREATE PROCEDURE sp_InsertProduct
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10,2),
    @CategoryId INT
AS
BEGIN
    INSERT INTO Product (ProductName, Price, CategoryId)
    VALUES (@ProductName, @Price, @CategoryId);
END
GO

CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10,2),
    @CategoryId INT
AS
BEGIN
    UPDATE Product
    SET ProductName = @ProductName,
        Price = @Price,
        CategoryId = @CategoryId
    WHERE ProductId = @ProductId;
END
GO

CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Product WHERE ProductId = @ProductId;
END
GO


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Product;
END
GO

-- 3. Functions
-- Get Category Name
CREATE FUNCTION fn_GetCategoryName(@CategoryId INT)
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @Name NVARCHAR(100);
    SELECT @Name = CategoryName FROM Category WHERE CategoryId = @CategoryId;
    RETURN ISNULL(@Name, 'Unknown');
END
GO

-- Count Products by Category
CREATE FUNCTION fn_GetProductsCountByCategory(@CategoryId INT)
RETURNS INT
AS
BEGIN
    DECLARE @Count INT;
    SELECT @Count = COUNT(*) FROM Product WHERE CategoryId = @CategoryId;
    RETURN ISNULL(@Count, 0);
END
GO

-- 4. Views
CREATE VIEW vw_ProductWithCategory
AS
SELECT 
    P.ProductId,
    P.ProductName,
    P.Price,
    C.CategoryName
FROM Product P
JOIN Category C ON P.CategoryId = C.CategoryId;
GO