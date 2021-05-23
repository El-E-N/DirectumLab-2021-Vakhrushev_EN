use STUDYTrace;

go
create schema schema1;

go
declare tbl_space cursor 
	for
	select 
	  schemas.name, objects.name
	from 
	  sys.objects objects
	  inner join sys.schemas schemas on objects.schema_id = schemas.schema_id
	where type = 'U' order by 1

declare @template varchar(max);

open tbl_space
declare @sch_name sysname;
declare @tbl_name sysname;
fetch next from tbl_space into @sch_name, @tbl_name;
while (@@fetch_status = 0)
begin
  alter schema schema1
  transfer [@sch_name].[@tbl_name];
  fetch next from tbl_space into @sch_name, @tbl_name;
end
close tbl_space;
deallocate tbl_space;