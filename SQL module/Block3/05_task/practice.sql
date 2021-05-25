--1
use Labstudy;

--2
go
alter table Customers
add constraint d_rating default 100 for rating

--3
go
insert Customers
(cnum, cname, city, snum)
values
(2012, 'Деточкин', 'Ижевск', 1001)
select * from Customers
where cnum=2012

alter table Salespeople
add constraint d_city default 'Ижевск' for city

--4
go
alter table Salespeople
add constraint ch_comm check (comm > 0)

go
update Salespeople
set comm = -0.13
where snum = 1001

go
alter table Orders
add constraint ch_amt check (amt > 0)

--5
go
alter table Customers
add constraint pk_cust_cnum primary key clustered (cnum)

go
alter table Salespeople
add constraint pk_cust_snum primary key clustered (snum)

go
alter table Orders
add constraint pk_cust_onum primary key clustered (onum)

go
exec sp_helpconstraint Customers
exec sp_help pk_cust_cnum

exec sp_helpconstraint Salespeople
exec sp_help pk_cust_snum

exec sp_helpconstraint Orders
exec sp_help pk_cust_onum

--6
go
alter table Salespeople
nocheck constraint ch_comm

update Salespeople
set comm = -0.13
where snum = 1001

go
alter table Salespeople
check constraint ch_comm

update Salespeople
set comm = 0.12
where snum = 1001
