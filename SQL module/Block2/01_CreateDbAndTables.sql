create database DbSales;

go
use DbSales

go
create table Customers
(
	Id int identity primary key not null,
	LastName nvarchar(20) not null,
	FirstName nvarchar(20) not null,
	Patronymic nvarchar(20) not null,
	City nvarchar(20) not null
);

go
create table Sellers
(
	Id int identity primary key not null,
	LastName nvarchar(20) not null,
	FirstName nvarchar(20) not null,
	Patronymic nvarchar(20) not null,
	City nvarchar(20) not null,
	CommissionPercent numeric(3, 0) not null
);

go
create table Orders
(
	Id int identity primary key not null,
	Specification nvarchar(1000) not null,

	Amount numeric(18, 9) not null
		constraint CK_Order_Amount check(Amount > 0),

	OrderDateTime datetime not null,
	CustomerId int not null references Customers(Id),
	SellerId int not null references Sellers(Id)
);

go
create table OrdersHistory
(
	Id int identity primary key not null,
	OperationType nvarchar(50) not null,
	OperationDateTime datetime not null default getdate(),
	OrderDateTime datetime not null,
	OrderId int not null,
	CustomerId int not null,
	SellerId int not null
);
