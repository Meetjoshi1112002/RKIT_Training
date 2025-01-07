SELECT
    s.ServiceType,
    s.SubServiceType,
    s.Price,
    s.Quantity,
    s.ServingDate,
    s.ServingTime,
    s.PaymentStatus,
    p.PaymentAmount,
    p.PaymentStatus,
    CONCAT(e.LastName, ' ', e.FirstName) AS Employee,
    CONCAT(sp.LastName, ' ', sp.FirstName) AS Provider
FROM ServiceLogs s
INNER JOIN Payments p 
    ON s.ProviderId = p.ProviderId
    AND s.EmployeeId = p.EmployeeId
    AND MONTH(s.ServingDate) = p.TranscationMonth
    AND YEAR(s.ServingDate) = p.TranscationYear
INNER JOIN Employees e
    ON s.EmployeeId = e.Id
INNER JOIN ServiceProvider sp
    ON s.ProviderId = sp.Id
WHERE s.ProviderId = 1
AND s.EmployeeId = 0
AND MONTH(s.ServingDate) = 1
AND YEAR(s.ServingDate) = 2025;

