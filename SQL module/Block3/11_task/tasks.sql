use STUDYTrace;

go
create schema schema1;

go
declare tbl_space cursor 
	for
	select 
	  N'alter schema schema1
      transfer ' + quotename(schemas.name) + N'.' + quotename(objects.name) + ';'
	from 
	  sys.objects objects
	  inner join sys.schemas schemas on objects.schema_id = schemas.schema_id
	where type = 'U'

open tbl_space
declare @template nvarchar(max);
fetch next from tbl_space into @template;
while (@@fetch_status = 0)
begin
  execute sp_executesql @template;
  fetch next from tbl_space into @template;
end
close tbl_space;
deallocate tbl_space;
