use Labstudy;

--1, 4
select 
  t1.cname name1,
  t2.cname name2
from Customers t1
join Customers t2
on t1.cname <> t2.cname
where t1.snum = t2.snum

--2
update Salespeople
set comm *= 0.9

--3
--DATEPART( interval, date )
--функция DATEPART возвращает заданную часть заданной даты в виде целочисленного значения.
--interval - интервал времени/даты, который вы хотите получить с даты
--date - дата использования для получения значения интервала.
--Пример: SELECT DATEPART(year, '25.12.2017');

--5
select cnum, onum, sum(amt) as Summa
from Orders 
group by rollup (cnum, onum)
having sum(amt) > 150 
order by cnum 

--6
select cnum, grouping(cnum), onum, grouping(Onum), sum(amt)
from Orders 
group by rollup (cnum, onum)
having sum(amt) > 150 
	order by cnum 
