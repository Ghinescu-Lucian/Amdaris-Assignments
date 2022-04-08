USE [Ghini-Bikes];
SELECT COUNT(dbo.Orders.ID),Username FROM dbo.Orders, dbo.Users WHERE UserID=dbo.Users.ID GROUP BY dbo.Users.Username;