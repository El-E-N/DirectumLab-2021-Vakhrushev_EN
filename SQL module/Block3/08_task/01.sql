use Labstudy;

--1
begin tran
  insert Salespeople (snum, sname, city, comm)
  values(1099, '���������', '��������', 0.1);

  select * from Salespeople

--5
rollback
-- ��� ������ 1099