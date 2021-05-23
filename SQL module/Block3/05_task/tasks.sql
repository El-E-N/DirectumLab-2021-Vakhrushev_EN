use Labstudy;

--1
go
create table Table1
(
  id int unique
);

-- не работает
insert into Table1
values 
(null),
(null);

--2
go
alter table Orders
add foreign key(cnum) references Customers(cnum)

select * from Orders;
select * from Customers;

delete Customers
where cnum = 2001;

--не работает
select * from Orders;
select * from Customers;

--3
go
alter table Orders
add foreign key(cnum) references Customers(cnum) on delete cascade;

go
select * from Orders;
select * from Customers;

go
delete Customers
where cnum = 2001;

go
select * from Orders;
select * from Customers;