use Labstudy;

--a
select * from Orders
where amt > 
    (select avg(amt)
	from Orders
    where odate = '23/09/1990')

--b
select * from Orders
where 
  (select city 
  from Salespeople 
  where snum = Orders.snum) in ('Ижевск', 'Томск')

--c
select * from Salespeople
where 
  (select count(*) from Customers 
  where snum = Salespeople.snum) > 1

-- дополнение
select * 
from Salespeople s
where 
  (select COUNT(*)
  from Customers c
  where c.snum = s.snum) > 1

select *
from Salespeople s
where 
  exists 
    (select * from Customers c
    where c.snum = s.snum
	group by c.snum
	having COUNT(c.snum) > 1)
-- второй запрос - дольше