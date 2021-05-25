use Labstudy;

--2, 4
go
set transaction isolation level read uncommitted;
select * from Salespeople with (nolock)