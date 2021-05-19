USE salesdb;

GO
INSERT INTO Sellers (LastName, FirstName, Patronymic, City, CommissionPercent)
VALUES
('Zhukov', 'Ivan', 'Genadievich', 'Izhevsk', 10.0),
('Sergeev', 'Sergey', 'Sergeevich', 'Izhevsk', 20.5),
('Antonov', 'Anton', 'Antonovich', 'Moscow', 12)

GO
INSERT INTO Customers (LastName, FirstName, Patronymic, City)
VALUES
('Ivanov', 'Ivan', 'Ivanovich', 'Izhevsk'),
('Alekseev', 'Aleksey', 'Alekseevich', 'Izhevsk'),
('Lebedev', 'Nikita', 'Alekseevich', 'Moscow'),
('Lvov', 'Lev', 'Lvovich', 'Izhevsk'),
('Petrov', 'Petr', 'Petrovich', 'Moscow')

GO
INSERT INTO Orders (Specification, Amount, OrderDateTime, City, CommissionPercent, CustomerId, SellerId)
VALUES
(
	'Описание первого заказа', 2000, '01/01/2021 12:00:00', 'Izhevsk', 13.0, '1', '1'
),
(
	'Описание второго заказа', 1000, '22/01/2021 12:00:00', 'Moscow', 45.0, '3', '3'
),
(
	'Описание третьего заказа', 30000, '03/01/2021 12:00:00', 'Izhevsk', 21.0, '4', '2'
),
(
	'Описание четвертого заказа', 500, '10/01/2021 12:00:00', 'Moscow', 1.0, '5', '3'
),
(
	'Описание пятого заказа', 12500, '10/02/2021 12:00:00', 'Moscow', 1.0, '1', '3'
)
