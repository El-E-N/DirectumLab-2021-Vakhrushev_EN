use DbSales;

go
insert into Sellers (LastName, FirstName, Patronymic, City, CommissionPercent)
values
('Zhukov', 'Ivan', 'Genadievich', 'Izhevsk', 10),
('Sergeev', 'Sergey', 'Sergeevich', 'Izhevsk', 20),
('Antonov', 'Anton', 'Antonovich', 'Moscow', 12)

go
insert into Customers (LastName, FirstName, Patronymic, City)
values
('Ivanov', 'Ivan', 'Ivanovich', 'Izhevsk'),
('Alekseev', 'Aleksey', 'Alekseevich', 'Izhevsk'),
('Lebedev', 'Nikita', 'Alekseevich', 'Moscow'),
('Lvov', 'Lev', 'Lvovich', 'Izhevsk'),
('Petrov', 'Petr', 'Petrovich', 'Moscow')

go
insert into Orders (Specification, Amount, OrderDateTime, CustomerId, SellerId)
values
('�������� ������� ������', 2000, '2021-01-01T12:00:00', 1, 1),
('�������� ������� ������', 1000, '2021-01-22T12:00:00', 3, 3),
('�������� �������� ������', 30000, '2021-03-01T12:00:00', 4, 2),
('�������� ���������� ������', 500, '2021-10-01T12:00:00', 5, 3),
('�������� ������ ������', 12500, '2021-10-02T12:00:00', 1, 3),
('�������� ������� ������', 3500, '2021-10-02T12:00:00', 1, 2),
('�������� �������� ������', 32500, '2021-10-02T12:00:00', 1, 2),
('�������� �������� ������', 1000, '2021-10-02T12:00:00', 2, 3),
('�������� �������� ������', 10000, '2021-10-02T12:00:00', 2, 2),
('�������� �������� ������', 11100, '2021-10-02T12:00:00', 3, 3),
('�������� ������������� ������', 11100, '2021-10-02T12:00:00', 3, 1)
