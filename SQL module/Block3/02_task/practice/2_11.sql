use Labstudy;

--a
select * from Orders
where 
  snum = 
    (select snum
    from Salespeople
    where sname = '������')

--b
select * from Orders
where 
  snum = 
    (select DISTINCT snum
	from Orders
    where cnum = 2001)

--c
select * from Orders
where
  amt >
    (select avg(amt)
	from Orders)