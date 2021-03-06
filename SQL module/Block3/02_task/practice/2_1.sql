create database Labstudy;

go
use Labstudy;

create table Customers
(
  cnum int not null,
  cname varchar(20) not null,
  city varchar(15) not null,
  rating int not null,
  snum int not null
);

go
create table Salespeople
(
  snum int not null,
  sname varchar(20) not null,
  city varchar(15) not null,
  comm float not null
);

go
create table Orders
(
  onum int not null,
  amt float not null,
  odate datetime not null,
  cnum int not null,
  snum int not null,
);
