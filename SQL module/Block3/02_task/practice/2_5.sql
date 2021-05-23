use Labstudy;

--a
select * from Customers
where 
  city = 'Таллин'
  or city = 'Ижевск';
--58 spid

select * from Customers
where 
  city in ('Таллин', 'Ижевск');
--58 spid

--b
select * from SalesPeople
where 
  comm >= 0.1
  and comm <= 0.12;

select * from SalesPeople
where comm between 0.1 and 0.12;

--c
select * from Customers
where city like 'М%';
-- %: Строка любой длины; _: Любой одиночный символ