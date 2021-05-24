use Labstudy;

select sname, comm
from SalesPeople;

--d
select cname, rating, city
from Customers; 

--e
--0.003 sec

--f
select snum
from Orders;
--0.003 sec

select distinct snum
from Orders;
--0.006 sec
-- distinct - убирает одинаковые строки

--g
select distinct snum
from Orders;

--h
select cname, city
from Customers
where city = 'Москва';

--i
select * from Customers
where rating = 300;

--j
select * from Orders
where amt > 2000;

--k
select * from Orders
where 
  odate = '23.10.1990'
  and amt > 159;
--0.003 sec

set dateformat DMY;
select * from Orders
where 
  odate = '23.10.1990'
  and amt > 159;
--0.003 sec. SET DATEFORMAT DMY не влияет на производительность.

--l
select * from Customers
where city = 'Москва'
union select * from Customers
where rating > 200;
--0.007 sec

--m
--1
go
select * from Orders
where not amt > 
    (select avg(amt)
	from Orders
    where odate = '23/09/1990')

--2
go
select * from Orders
where not
  (select city 
  from Salespeople 
  where snum = Orders.snum) in ('Ижевск', 'Томск')

--3
go
select * from Salespeople
where not
  (select count(*) from Customers 
  where snum = Salespeople.snum) > 1

--4
go
select * 
from Salespeople s
where not
  (select COUNT(*)
  from Customers c
  where c.snum = s.snum) > 1

--n
select * from Orders
where not ((odate = '10.03.1990' and snum > 1002)
or amt > 2000.00);
--упрощается
select * from Orders
where 
  (odate <> '10.03.1990'
  or snum <= 1002)
  and amt <= 2000.00;
