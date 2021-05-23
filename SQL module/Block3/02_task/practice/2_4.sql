use Labstudy;

select sname, comm
from SalesPeople;

--d
select cname, rating, city
from Customers; 

--e
--0.004 sec

--f
select snum
from Orders;
--0.003 sec

select distinct snum
from Orders;
--0.006 sec
-- distinct - ������� ���������� ������

--g
select distinct snum
from Orders;

--h
select cname, city
from Customers
where city = '������';

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
--0.004 sec

set dateformat DMY;
select * from Orders
where 
  odate = '23.10.1990'
  and amt > 159;
--0.003 sec. SET DATEFORMAT DMY �������� ������������������ 

--l
select * from Customers
where city = '������'
union select * from Customers
where rating > 200;
--0.01 sec

--m
select * from Customers
where not city = '������'
union select * from Customers
where not rating > 200;

--n
select * from Orders
where not ((odate = '10.03.1990' and snum > 1002)
or amt > 2000.00);
--����������
select * from Orders
where 
  (odate <> '10.03.1990'
  or snum <= 1002)
  and amt <= 2000.00;
