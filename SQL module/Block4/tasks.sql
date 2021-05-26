create database AdventureWorksLT;
-- перезаписал через панель слева

use AdventureWorksLT;

--1.	Отобразить названия организации всех покупателей из Торонто.
go
select c.CompanyName
from SalesLT.Customer c
join SalesLT.CustomerAddress ca
on c.CustomerID = ca.CustomerID
join SalesLT.[Address] a
on ca.AddressID = a.AddressID
where a.City = 'Toronto'
order by c.CompanyName

--2.	Сколько товаров со стоимостью (ListPrice) выше 1000 было продано?
go
select sum(sod.OrderQty) as [count] 
from SalesLT.SalesOrderDetail sod
join SalesLT.Product p
on sod.ProductID = p.ProductID
where p.ListPrice > 1000

--3.	Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.
go
select c1.CompanyName cname
from SalesLT.Customer c1
group by c1.CompanyName
having 
  (select sum(soh.TotalDue) 
  from SalesLT.SalesOrderHeader soh
  join SalesLT.Customer c2
  on soh.CustomerID = c2.CustomerID
  where c2.CompanyName = c1.CompanyName) > 50000

--4.	Какие компании заказывали продукт (ProductModel) «Racing Socks»?
go
select c.CompanyName cname
from SalesLT.Customer c
join SalesLT.SalesOrderHeader soh
on c.CustomerID = soh.CustomerID
join SalesLT.SalesOrderDetail sod
on sod.SalesOrderID = soh.SalesOrderID
join SalesLT.Product p
on p.ProductID = sod.ProductID
join SalesLT.ProductModel pm
on pm.ProductModelID = p.ProductModelID
where pm.[Name] = 'Racing Socks'
group by c.CompanyName

--5.	Отобразить 25 товаров с наибольшим суммарным чеком (количество * стоимость товара).
go
select top 25 p.[Name] from SalesLT.Product p
join SalesLT.SalesOrderDetail sod
on p.ProductID = sod.ProductID
group by p.ProductID, p.[Name]
order by
  (select sum(sod.LineTotal)
  from SalesLT.SalesOrderDetail sod
  where sod.ProductID = p.ProductID) desc

--6.	Сгруппировать заказы по диапазону стоимости: 0…99, 100...999, 1000…9999, свыше 10000. 
--      Для каждого диапазона отобразить количество заказов и общую стоимость.
go
select 
  tbl.[range], 
  count(*) as [count], 
  sum(tbl.TotalDue) as [sum] 
from
  (select *, '0-99' as [range]
  from SalesLT.SalesOrderHeader 
  where TotalDue between 0 and 99
  union
  select *, '100-999' as [range] 
  from SalesLT.SalesOrderHeader 
  where TotalDue between 100 and 999
  union
  select *, '1000-9999' as [range] 
  from SalesLT.SalesOrderHeader 
  where TotalDue between 1000 and 9999
  union
  select *, '10000+' as [range] 
  from SalesLT.SalesOrderHeader 
  where TotalDue > 10000) tbl
group by [range]

--7.	Отобразить список компаний, содержащих “bike” или “cycle” в названии. 
--      Отсортировать выборку так, чтобы сначала отображались компании с «bike», а затем с «cycle».
go
select distinct CompanyName cname
from SalesLT.Customer c1
where c1.CompanyName like '%bike%'
union all
select distinct CompanyName cname
from SalesLT.Customer c2
where c2.CompanyName like '%cycle%'

-- 8.	Отобразите 10 наиболее важных для продаж городов.
go
select top 10 tbl.City, sum(soh.TotalDue)
from SalesLT.[Address] tbl
join SalesLT.CustomerAddress ca
on ca.AddressID = tbl.AddressID
join SalesLT.SalesOrderHeader soh
on soh.CustomerID = ca.CustomerID
where tbl.City = tbl.City
group by tbl.City
order by sum(soh.TotalDue) desc