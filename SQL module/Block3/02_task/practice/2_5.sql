use Labstudy;

--a
select * from Customers
where 
  city = '������'
  or city = '������';
--58 spid

select * from Customers
where 
  city in ('������', '������');
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
where city like '�%';
-- %: ������ ����� �����; _: ����� ��������� ������