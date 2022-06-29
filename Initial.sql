use AutoService

INSERT Admins
VALUES
	('admin', '$2a$11$q80qpsSVmSnFZhqYijkGA.D/zM9QQnOdxYryKTnjwyBmY.60X8fS6')

INSERT OrderStatus
VALUES
	(0, 'Accepted'),
	(1, 'Processing'),
	(2, 'Fulfilled'),
	(3, 'Canceled')

INSERT ModelTypes
VALUES
	(0, 'Sedan'),
	(1, 'Coupe'),
	(2, 'Hatchback'),
	(3, 'SUV'),
	(4, 'Pickup'),
	(5, 'Convertible')
INSERT Employees
VALUES
	('11111111-1111-1111-1111-1111111111111', 'Не', 'Назначен', 0)