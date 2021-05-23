use Labstudy;

select snum, odate, Max(amt)
	from Orders
group by snum, odate 
having Max(amt) > 1000
