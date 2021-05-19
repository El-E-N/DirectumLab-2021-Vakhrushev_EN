USE salesdb

GO
CREATE TRIGGER Orders_DELETE
ON Orders
AFTER DELETE
AS
INSERT INTO HistoryOfOrders (Operation, OrderDateTime, CustomerId, SellerId)
SELECT 'DELETE', OrderDateTime, CustomerId, SellerId
FROM DELETED

GO
CREATE TRIGGER Orders_INSERT
ON Orders
AFTER INSERT
AS
INSERT INTO HistoryOfOrders (Operation, OrderDateTime, CustomerId, SellerId)
SELECT 'INSERT', OrderDateTime, CustomerId, SellerId
FROM INSERTED

GO
CREATE TRIGGER Orders_UPDATE
ON Orders
AFTER UPDATE
AS
INSERT INTO HistoryOfOrders (Operation, OrderDateTime, CustomerId, SellerId)
SELECT 'UPDATE', OrderDateTime, CustomerId, SellerId
FROM INSERTED

GO
CREATE TRIGGER OrdersCheckCity_INSERT
ON Orders
AFTER INSERT
AS
DELETE Orders
WHERE EXISTS (SELECT * FROM Customers WHERE Id = CustomerId AND City <> Orders.City)
OR EXISTS (SELECT * FROM Sellers WHERE Id = SellerId AND City <> Orders.City)