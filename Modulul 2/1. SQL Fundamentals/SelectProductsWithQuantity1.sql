USE [Ghini-Bikes];

Select Manufacturer,Model,Price FROM dbo.Products AS p WHERE Quantity = 1 ORDER BY Year DESC;