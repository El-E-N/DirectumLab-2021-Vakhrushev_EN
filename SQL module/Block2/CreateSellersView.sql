USE salesdb;
GO
CREATE VIEW SellersView (Id, LastName, FirstName, Patronymic, CommissionPercent, CommissionSum) AS
SELECT S.Id,
		S.LastName,
		S.FirstName,
		S.Patronymic,
		S.CommissionPercent,
		(SUM(O.Amount) * S.CommissionPercent / 100)
FROM Sellers AS S JOIN Orders AS O ON S.Id = O.SellerId
GROUP BY S.Id, S.LastName,
		S.FirstName,
		S.Patronymic,
		S.CommissionPercent
