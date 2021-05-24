--1
go
create login Elen1 with password = 'qwerty';

--2
go
use Labstudy;
create user Elen1 for login Elen1;

--3
go
execute sp_addsrvrolemember Elen1, sysadmin