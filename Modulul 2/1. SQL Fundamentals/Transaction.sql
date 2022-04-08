BEGIN TRY
	BEGIN TRANSACTION TR1
		UPDATE dbo.Users SET Email='lukyghi20@yahoo.com' WHERE Username = 'Lucian'
		UPDATE dbo.Orders SET Address='Strada x, Jud. Y, Romania' WHERE  ID = 1
		UPDATE dbo.Products SET Quantity = 5 WHERE ID = 4
		DELETE FROM dbo.OrdersItems WHERE ID =3
		DELETE FROM dbo.Users WHERE Username = 'Cristiano'
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION TR1
END CATCH