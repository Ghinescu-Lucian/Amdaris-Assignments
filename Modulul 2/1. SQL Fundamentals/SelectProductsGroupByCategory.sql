USE [Ghini-Bikes];
SELECT COUNT(Quantity),Category FROM dbo.Products GROUP BY Category;