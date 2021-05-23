use Labstudy;

--a
select sum(amt) as [SUM]
from Orders
where odate <= '05.10.1990';

--b
select min(comm) from Salespeople;

--c
select avg(comm) from Salespeople;

--d
select count(*)
from Customers
where rating < 200;

select count(cnum)
from Customers
where rating < 200;

--e
select count(distinct snum) from Orders;

--f
select max(amt) from Orders; 

--g
select snum, max(amt) as [max], 
  (select sname from Salespeople where snum = Orders.snum)
from Orders
group by snum

--h
select snum, odate, Max(amt) as [max]
from Orders
group by snum, odate
