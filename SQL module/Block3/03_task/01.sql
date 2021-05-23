create database STUDYTrace;

--1
go
use STUDYTrace;

--2
go
select databasepropertyex ('STUDYTrace', 'IsAutoCreateStatistics');
select databasepropertyex ('STUDYTrace', 'IsAutoUpdateStatistics');

go
alter database STUDYTrace
set 
auto_create_statistics off,
auto_update_statistics off

go
select databasepropertyex ('STUDYTrace', 'IsAutoCreateStatistics');
select databasepropertyex ('STUDYTrace', 'IsAutoUpdateStatistics');

--3
go
alter database STUDYTrace modify file
(name='STUDYTrace', filegrowth=10%, maxsize=100mb)

go
dbcc shrinkdatabase (STUDYTrace, 25);
dbcc shrinkfile ('STUDYTrace', 25);

--4 
select * 
from sys.objects

--5
select * 
from INFORMATION_SCHEMA.VIEWS

--6
sp_help;

exec sp_helpdb N'STUDYTrace';

create table Temptable
(
  id int primary key not null,
);

exec sp_helpindex N'Temptable';