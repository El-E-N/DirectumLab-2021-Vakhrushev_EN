use Labstudy;

go
create procedure StudyChangeCity
  @x bit,
  @n int,
  @y varchar(15),
  @z varchar(15) output
as
begin
  if @x = 0
    begin
	  select @z = city from Customers
      where cnum = @n;
	  update Customers
      set city = @y
      where cnum = @n;
    end
  else
    begin
	  select @z = city from Salespeople
      where snum = @n;
	  update Salespeople
      set city = @y
      where snum = @n;
    end
end

go
select * from Customers;
go
declare @z varchar(15);
print @z;
exec StudyChangeCity 0, 2002, 'Москва', @z output;
print @z;
go
select * from Customers;
