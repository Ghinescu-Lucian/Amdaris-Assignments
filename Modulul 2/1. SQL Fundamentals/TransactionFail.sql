USE [Ghini-Bikes];

BEGIN TRY
	BEGIN TRANSACTION 
		UPDATE dbo.Users SET Email='lukyghi20@yahoo.com' WHERE Username = 'Lucian'
		UPDATE dbo.Orders SET Address='Strada x, Jud. Y, Romania' WHERE  ID = 1
		UPDATE dbo.Products SET Quantity = 30 WHERE ID = 4
		DELETE FROM dbo.OrdersItems WHERE ID =20
		DELETE FROM dbo.Users WHERE Username = 'Luky'
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK;
END CATCH