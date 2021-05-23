use STUDYTrace;

--1
go
create trigger UpdCnum on Customers
for update
as
   declare @NumRow int
   set @NumRow = @@rowcount
   if update(cnum) 
      begin
      if @NumRow=1
         update Orders
            set Orders.cnum=inserted.cnum
            from Orders, inserted, deleted
            where Orders.cnum=deleted.cnum 
      else
         rollback
      end

go
create trigger UpdSnum on Salespeople
for update
as
   declare @NumRow int
   set @NumRow = @@rowcount
   if update(snum) 
      begin
      if @NumRow>1
         rollback
      else
         if exists(select * 
                   from deleted d 
                   join Customers c 
                   on d.snum=c.snum) or 
            exists(select * 
                   from deleted d 
                   join Orders o 
                   on d.snum=o.snum)
            rollback
      end

--2
go
create trigger InDocuments
on Documents
for insert
as
update o
  set ocamt += (select sum(dcamt) from inserted i where i.onum = o.onum),
      osamt += (select sum(dsamt) from inserted i where i.onum = o.onum)
FROM Orders o 
WHERE o.onum IN (SELECT DISTINCT onum FROM inserted)

select *
from Documents;

go
create trigger OutDocuments
on Documents
for delete
as
update o
  set ocamt -= (select sum(dcamt) from deleted d where d.onum = o.onum),
      osamt -= (select sum(dsamt) from deleted d where d.onum = o.onum)
FROM Orders o
WHERE o.onum IN (SELECT DISTINCT onum FROM deleted)

--3
go
create procedure CreateBuyersDebts
as
  begin
    create table #ReportV
    (
      onum int,
      cnum int,
      dolg float,
      pamt float,
      pdateamt datetime,
      snum int
    );
	select o.onum, 
       o.cnum, 
       o.osamt-o.ocamt as dolg, 
       (select top 1 dcamt 
           from Documents d 
           where d.onum = o.onum and dcamt > 0
           order by ddate desc) as pamt, 
       (select top 1 ddate 
           from Documents d 
           where d.onum = o.onum  and dcamt > 0
           order by ddate desc) as pdateamt, 
       o.snum
   into ReportV
   from Orders o
  end

exec CreateBuyersDebts;
select * from ReportV;