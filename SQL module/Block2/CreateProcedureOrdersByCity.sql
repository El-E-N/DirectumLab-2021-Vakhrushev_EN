USE salesdb;
GO
CREATE PROCEDURE OrdersByCity
	@city NVARCHAR(20)
AS
SELECT * FROM Orders
WHERE City = @city
