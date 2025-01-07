INSERT INTO Employees (Id,FirstName, LastName, DateOfBirth, Gender, PhoneNumber)
VALUES
(0,'Company','Company','1998-01-01','Others','0000000000'),
(1,'Meet', 'joshi', '2002-11-01', 'Male', '8980201842'),
(2,'Navneet', 'kumar', '2003-10-29', 'Male', '8765432109'),
(3,'Rohanshu', 'Banodha', '2003-09-15', 'Male', '7654321098');


INSERT INTO ServiceProvider (FirstName, LastName, Gender, PhoneNumber, ServiceType, CompanyName)
VALUES
('Anil', 'Bhai', 'Male', '6543210987', 'Beverages', 'Ganesh Tea'),
('Hamir', 'Bhai', 'Male', '5432109876', 'Water', 'Pure Water Co.'),
('Laxmi', 'Ben', 'Female', '4321098765', 'Cleaning', 'CleanX Services');


INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
VALUES
(1,0, 'Beverages', 'Tea', 10, 4, '2025-01-06', '11:00:00', 'Pending'),
(1,0, 'Beverages', 'Coffee', 15, 2, '2025-01-06', '11:00:00', 'Pending'),
(1,0, 'Beverages', 'Tea', 10, 4, '2025-01-06', '4:00:00', 'Pending'),
(1,0, 'Beverages', 'Coffee', 15, 2, '2025-01-06', '4:00:00', 'Pending'), --  Beverages entry for Monday
(2,0, 'Water', 'Jug', 40, 1, '2025-01-06', '09:00:00', 'Pending');


-- Employees here
INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
VALUES
(1,0, 'Beverages', 'Tea', 10, 4, '2025-01-01', '11:00:00', 'Pending'),
(1,0, 'Beverages', 'Coffee', 15, 2, '2025-01-01', '11:00:00', 'Pending'),
(1,0, 'Beverages', 'Tea', 10, 4, '2025-01-03', '4:00:00', 'Pending'),
(1,0, 'Beverages', 'Coffee', 15, 2, '2025-01-04', '4:00:00', 'Pending'); --  Dummy entry for Employee


INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
VALUES
(2,0, 'Water', 'Cargo', 30, 1, '2025-01-01', '09:00:00', 'Pending');


Update Payments
SET PaymentStatus = 'Paid', PaymentTime = NOW()
WHERE ProviderId = 1
AND EmployeeId = 1
AND TranscationMonth = 12 
AND TranscationYear = 2024;



select * from Employees;

select * from ServiceProvider;

select * from Payments;

select * from ServiceLogs;

Drop database officeopsdb;

TRUNCATE TABLE Employees;

TRUNCATE TABLE ServiceProvider;

TRUNCATE TABLE ServiceLogs;

TRUNCATE TABLE Payments;