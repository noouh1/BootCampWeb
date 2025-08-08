use AdventureWorksLT2022;

select * from SalesLT.SalesOrderHeader;
select * from SalesLT.Product;

-- Select SalesOrderID and ShipDate for orders shipped between 2002-07-28 and 2014-07-29
select Salesorderid, shipdate 
from SalesLT.SalesOrderHeader
where ShipDate between '2002-07-28' and '2014-07-29';

-- Select ProductID and Name for products with StandardCost less than 110
select productID, Name 
from SalesLT.Product
where StandardCost < 110;

-- Select ProductID and Name for products where Weight is NULL
select productID, Name 
from SalesLT.Product
where Weight is null;

-- Select all products where Color is Silver, Red, or Black
select * 
from SalesLT.Product
where Color = 'Silver' or Color = 'Red' or Color = 'Black';

-- Select all products where Name starts with 'B'
select * 
from SalesLT.Product
where Name like 'B%';

-- Update ProductDescription to a new string for ProductDescriptionID = 3
UPDATE SalesLT.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3;

-- Select ProductDescriptions containing an underscore character
select * 
from SalesLT.ProductDescription
where Description like '%\_%' escape '\';

-- Calculate total due for each order date between 2001-07-01 and 2014-07-31
select orderdate, SUM(TotalDue) as total 
from SalesLT.SalesOrderHeader
where OrderDate between '7/1/2001' and '7/31/2014'
group by orderdate;

-- Calculate average of distinct ListPrice values from Product
select AVG(distinct ListPrice) as price 
from SalesLT.Product;

-- Display product info with Name and ListPrice between 100 and 120, ordered by ListPrice
select CONCAT('The ' , Name ,' is only! ', ListPrice) as info 
from SalesLT.Product
where ListPrice between 100 and 120
order by ListPrice;

-- Show today's date in 'yyyy-MM-dd' format and full day-month-year format using UNION
select FORMAT(GETDATE(), 'yyyy-MM-dd')    
UNION
select FORMAT(GETDATE(), 'dddd, MMMM dd, yyyy');
