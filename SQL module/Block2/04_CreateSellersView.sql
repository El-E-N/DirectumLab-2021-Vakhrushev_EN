use DbSales;

go
create view SellersView (Id, LastName, FirstName, Patronymic, CommissionPercent, CommissionSum) 
as
select 
  S.Id,
  S.LastName,
  S.FirstName,
  S.Patronymic,
  S.CommissionPercent,
  (sum(O.Amount) * S.CommissionPercent / 100)
from Sellers as S 
  join Orders as O on S.Id = O.SellerId
group by
  S.Id, 
  S.LastName,
  S.FirstName,
  S.Patronymic,
  S.CommissionPercent
