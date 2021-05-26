create database AdventureWorksLT;
-- перезаписал через панель слева

use AdventureWorksLT;

--1
go
select CompanyName
from SalesLT.Customer c
where exists
  (select CustomerID 
  from SalesLT.CustomerAddress ca
  where 
    CustomerID = c.CustomerID 
    and exists 
      (select AddressID 
	  from SalesLT.Address
      where 
  	    AddressID = ca.AddressID 
	    and City = 'Toronto'))

--2
go
select count(*) from SalesLT.SalesOrderDetail sod
where exists 
  (select ProductID from SalesLT.Product
  where 
    ProductID = sod.ProductID 
    and ListPrice > 1000)

--3
go
select distinct CompanyName cname
from SalesLT.Customer c1
where 
(select sum(TotalDue) from SalesLT.SalesOrderHeader
where CustomerID in 
  (select CustomerID 
  from SalesLT.Customer c2
  where c2.CompanyName = c1.CompanyName)) > 50000

--4
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

--5
go
select top 25 * from SalesLT.Product p
where p.ProductID in 
  (select distinct ProductID 
  from SalesLT.SalesOrderDetail)
order by
  (select sum(OrderQty * UnitPrice)
  from SalesLT.SalesOrderDetail sod
  where sod.ProductID = p.ProductID) desc

--6
go
select 
  [range], 
  count(*) as [count], 
  sum(LineTotal) as [sum] 
from
  (select *, '0-99' as [range]
  from SalesLT.SalesOrderDetail 
  where LineTotal between 0 and 99
  union
  select *, '100-999' as [range] 
  from SalesLT.SalesOrderDetail 
  where LineTotal between 100 and 999
  union
  select *, '1000-9999' as [range] 
  from SalesLT.SalesOrderDetail 
  where LineTotal between 1000 and 9999
  union
  select *, '10000+' as [range] 
  from SalesLT.SalesOrderDetail 
  where LineTotal > 10000) tbl
group by [range]

--7
go
select distinct CompanyName cname
from SalesLT.Customer c1
where c1.CompanyName like '%[Bb][Ii][Kk][Ee]%'
union all
select distinct CompanyName cname
from SalesLT.Customer c2
where c2.CompanyName like '%[Cc][Yy][Cc][Ll][Ee]%'

--8
go
select top 10 * from
  (select distinct a1.City 
  from SalesLT.[Address] a1) tbl
where exists
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
