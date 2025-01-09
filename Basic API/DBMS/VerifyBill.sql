SELECT
    s.ServiceType,
    s.SubServiceType,
    s.Price,
    s.Quantity,
    (Price*Quantity) AS Expense,
    s.ServingDate,
    s.ServingTime,
    s.PaymentStatus,
    p.PaymentAmount AS BILL_Amount,
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
WHERE s.ProviderId = 1 -- These are bill detials
AND s.EmployeeId = 1
AND MONTH(s.ServingDate) = 2
AND YEAR(s.ServingDate) = 2025;
 -- partions in sql expore this topic
