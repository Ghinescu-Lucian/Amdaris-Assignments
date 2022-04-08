USE [Ghini-Bikes];

SELECT COUNT(dbo.OrdersItems.ID),Name FROM dbo.OrdersItems,dbo.Orders WHERE OrderID=dbo.Orders.ID GROUP BY Name;