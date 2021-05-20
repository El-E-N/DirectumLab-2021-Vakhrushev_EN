use DbSales;

go
create procedure OrdersByCity
  @city nvarchar(20)
as
select * from Orders
where
  SellerId in (select Id from Sellers where Id = SellerId and City = @city)
