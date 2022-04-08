USE [Ghini-Bikes];
SELECT Manufacturer,Model,Year,Price FROM dbo.Products WHERE Manufacturer LIKE '[FC]%' ORDER BY Price;