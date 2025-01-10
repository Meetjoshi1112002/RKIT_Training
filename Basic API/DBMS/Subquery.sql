SELECT Id, FirstName, LastName
FROM Employees
WHERE FirstName LIKE '%Meet%' OR LastName LIKE '%^J%';

SELECT Id, ProviderId, EmployeeId, ServiceType, SubServiceType, Price
FROM ServiceLogs
WHERE ServiceType IN ('Beverages', 'Water');

explain( SELECT Id, FirstName, LastName
FROM Employees
WHERE Id IN (
    SELECT EmployeeId
    FROM ServiceLogs
    WHERE ProviderId = 2 -- Service provider with Id 2
));

SELECT 
    FirstName, 
    LastName,
    (SELECT SUM(Quantity) 
     FROM ServiceLogs 
     WHERE ServiceLogs.EmployeeId = Employees.Id 
     AND ServiceLogs.ServiceType = 'Beverages') AS TotalBeverages
FROM Employees
WHERE FirstName LIKE '%Meet%';

