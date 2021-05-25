use Labstudy;

--1
go
create view dbo.OrdNameView
as
select c.cname, s.sname, o.amt, o.odate
from Orders o
inner join Customers c
on o.cnum = c.cnum
inner join Salespeople s
on o.snum = s.snum

--2
go
select * from OrdNameView

--3
go
exec sp_helptext OrdNameView

--4
go
exec sp_depends OrdNameView

--5
exec sp_depends Orders
exec sp_depends Customers
