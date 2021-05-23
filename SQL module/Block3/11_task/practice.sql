use STUDYTrace;

go
declare tbl_space cursor 
	for
	select 
	  schemas.name + '.' + objects.name 
	from 
	  sys.objects objects
	  inner join sys.schemas schemas on objects.schema_id = schemas.schema_id
	where type = 'U' order by 1

open tbl_space
declare @tbl_name varchar(max)
fetch next from tbl_space into @tbl_name
while (@@fetch_status = 0)
begin
	exec sp_spaceused @tbl_name
	fetch next from tbl_space into @tbl_name
end
close tbl_space
deallocate tbl_space
