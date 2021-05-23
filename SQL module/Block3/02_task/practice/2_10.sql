use Labstudy;

select 
  Table1.cname, 
  Table2.cname, 
  Table1.rating
from Customers Table1
join Customers Table2
on Table1.rating = Table2.rating
where Table1.cname <> Table2.cname