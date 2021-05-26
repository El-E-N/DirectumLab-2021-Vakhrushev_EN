create database AdventureWorksLT;
-- перезаписал через панель слева

use AdventureWorksLT;

--1.	Отобразить названия организации всех покупателей из Торонто.
go
select CompanyName
from SalesLT.Customer c
join SalesLT.CustomerAddress ca
on c.CustomerID = ca.CustomerID
where ca.AddressID in
  (select a.AddressID 
  from SalesLT.[Address] a
  where City = 'Toronto')

--2.	Сколько товаров со стоимостью (ListPrice) выше 1000 было продано?
go
select sum(sod.OrderQty) as [count] 
from SalesLT.SalesOrderDetail sod
join SalesLT.Product p
on sod.ProductID = p.ProductID
where p.ListPrice > 1000

--3.	Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.
go
select distinct CompanyName cname
from SalesLT.Customer c1
where 
(select sum(TotalDue) from SalesLT.SalesOrderHeader
where CustomerID in 
  (select CustomerID 
  from SalesLT.Customer c2
  where c2.CompanyName = c1.CompanyName)) > 50000

--4.	Какие компании заказывали продукт (ProductModel) «Racing Socks»?
go
select distinct CompanyName cname
from SalesLT.Customer c1
where 'Racing Socks' in
  (select pm.[Name]
  from SalesLT.ProductModel pm
  where pm.ProductModelID in
    (select p.ProductModelID 
	from SalesLT.Product p
	where p.ProductID in
	  (select sod.ProductID 
      from SalesLT.SalesOrderDetail sod
	  where sod.SalesOrderID in
		(select soh.SalesOrderID 
		from SalesLT.SalesOrderHeader soh
		where soh.CustomerID in 
		  (select CustomerID
          from SalesLT.Customer c2
          where c2.CompanyName = c1.CompanyName)))))

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
  [range], 
  count(*) as [count], 
  sum(TotalDue) as [sum] 
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
select top 10 tbl.City
from SalesLT.[Address] tbl
group by tbl.City
having exists
  (select *
  from SalesLT.SalesOrderHeader
  where CustomerID in
    (select ca.CustomerID
    from SalesLT.CustomerAddress ca
    where ca.AddressID in
      (select a2.AddressID
      from SalesLT.[Address] a2
      where tbl.City = a2.City)))
order by
  (select sum(TotalDue)
  from SalesLT.SalesOrderHeader
  where CustomerID in
    (select ca.CustomerID
    from SalesLT.CustomerAddress ca
    where ca.AddressID in
      (select a2.AddressID
      from SalesLT.[Address] a2
      where tbl.City = a2.City))) desc