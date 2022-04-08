USE [Ghini-Bikes];

SELECT o.Name,o.Address,o.TotalCost,p.Manufacturer,p.Model,items.Quantity FROM dbo.Orders AS o
INNER JOIN dbo.OrdersItems as items ON o.ID = items.OrderID
INNER JOIN dbo.Products as p ON p.ID=items.ProductID
ORDER BY o.Name;