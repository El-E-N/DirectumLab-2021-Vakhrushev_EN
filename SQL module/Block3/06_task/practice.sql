use Labstudy;

--1
go
create index idx_cnum
on Orders(cnum)

--2
go
exec sp_helpindex Orders

--3
go
create index idx_snum
on Orders(snum)

--4
go
exec sp_helpindex Orders

--5
go
set statistics io on;
select * from Orders;

go
set statistics io off;
select * from Orders;

--6
go
set showplan_all on;
go
select * from Orders;
--pk_cust_onum

--7
DBCC SHOWCONTIG ('Orders');

--8
drop index Orders.idx_cnum;

--9
drop index Orders.idx_snum;
