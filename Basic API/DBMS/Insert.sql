INSERT INTO Employees (Id,FirstName, LastName, DateOfBirth, Gender, PhoneNumber)
VALUES
(0,'Company','Company','1998-01-01','Others','0000000000'),
(1,'Meet', 'joshi', '2002-11-01', 'Male', '8980201842'),
(2,'Navneet', 'kumar', '2003-10-29', 'Male', '8765432109'),
(3,'Rohanshu', 'Banodha', '2003-09-15', 'Male', '7654321098');


INSERT INTO ServiceProvider (FirstName, LastName, Gender, PhoneNumber, ServiceType, CompanyName)
VALUES
('Anil', 'Bhai', 'Male', '6543210987', 'Beverages', 'Ganesh Tea'),
('Amir', 'Bhai', 'Male', '5432109876', 'Water', 'Pure Water Co.'),
('Laxmi', 'Ben', 'Female', '4321098765', 'Cleaning', 'CleanX Services');


INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
VALUES
(1,0, 'Beverages', 'Tea', 10, 50, '2024-12-01', '10:00:00', 'Pending'),
(1,1, 'Beverages', 'Coffee', 15, 30, '2024-12-02', '11:00:00', 'Pending'),
(2,0, 'Water', 'Jug', 20, 10, '2024-12-03', '09:00:00', 'Pending');

INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
VALUES
(1,1, 'Beverages', 'Tea', 10, 50, '2023-12-01', '10:00:00', 'Pending');


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