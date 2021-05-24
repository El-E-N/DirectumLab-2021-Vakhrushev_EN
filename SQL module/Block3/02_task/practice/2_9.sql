use Labstudy;

--a
select * from Salespeople s, Customers c
order by s.snum

--b
select 
  c.cname, 
  c.city
from Customers c, Salespeople s
where 
  c.snum = s.snum
  and c.city = s.city

--c
select 
  s.sname,
  s.comm,
  (o.amt * s.comm) as [sum]
from Orders o, Salespeople s
where o.snum = s.snum
order by onum;
