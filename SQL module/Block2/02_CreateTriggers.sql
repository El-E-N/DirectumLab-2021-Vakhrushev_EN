use DbSales

go
create trigger OrdersDelete
on Orders
after delete
as
insert into OrdersHistory (OperationType, OrderDateTime, CustomerId, SellerId)
select 
  'DELETE', 
  OrderDateTime, 
  CustomerId, 
  SellerId
from deleted

go
create trigger OrdersInsert
on Orders
after insert
as
insert into OrdersHistory (OperationType, OrderDateTime, CustomerId, SellerId)
select
  'INSERT',
  OrderDateTime,
  CustomerId, 
  SellerId
from inserted

go
create trigger OrdersUpdate
on Orders
after update
as
insert into OrdersHistory (OperationType, OrderDateTime, CustomerId, SellerId)
select
  'UPDATE', 
  OrderDateTime, 
  CustomerId, 
  SellerId
from inserted

go
create trigger OrdersCheckCityInsert
on Orders
after insert
as
delete Orders
where
  Id in (select Id from inserted)
  and exists
  (
	select * from Customers, Sellers
	where 
	  Customers.Id = CustomerId
	  and Sellers.Id = SellerId
	  and Customers.City <> Sellers.City
  );
