use Labstudy;

--a
select * from Customers
where 
  city = '������'
  or city = '������';
--0.004 sec

select * from Customers
where 
  city in ('������', '������');
--0.003 sec
--������ �������� �������

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