use Labstudy;

go
insert into Customers
values
(2010, '��������', '������', 120, 1004),
(2011, '��������', '������', 130, 1001)

--a
go
insert into Salespeople
values (1005, '�����', '������', 0.11)

--b
go
update Salespeople
set comm = 0.17
where snum = 1005

--c
go
update Customers
set rating = 150
where rating < 150

--d
go
update Customers
set rating *= 2

--e
go
delete Customers
where cname = '��������'