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
('Описание первого заказа', 2000, '01-01-2021 12:00:00', '1', '1'),
('Описание второго заказа', 1000, '22-01-2021 12:00:00', '3', '3'),
('Описание третьего заказа', 30000, '03-01-2021 12:00:00', '4', '2'),
('Описание четвертого заказа', 500, '10-01-2021 12:00:00', '5', '3'),
('Описание пятого заказа', 12500, '10-02-2021 12:00:00', '1', '3'),
('Описание шестого заказа', 3500, '10-02-2021 12:00:00', '1', '2'),
('Описание седьмого заказа', 32500, '10-02-2021 12:00:00', '1', '2'),
('Описание восьмого заказа', 1000, '10-02-2021 12:00:00', '2', '3'),
('Описание девятого заказа', 10000, '10-02-2021 12:00:00', '2', '2'),
('Описание десятого заказа', 11100, '10-02-2021 12:00:00', '3', '3'),
('Описание одиннадцатого заказа', 11100, '10-02-2021 12:00:00', '3', '1')
