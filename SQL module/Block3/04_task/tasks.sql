use STUDYTrace;

--1
go
create table Documents
(
  dñamt float null,
  dsamt float null,
  ddate	datetime not null,
  onum	int	not null
);
select * from Documents;

--2
go
ALTER TABLE Documents
add dnum integer not null;

select * from Documents;