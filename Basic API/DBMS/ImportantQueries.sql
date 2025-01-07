-- Most important quries:

-- 1st: Most Frequently used service and thier provider
select s.ServiceType, CONCAT(sp.FirstName,' ',sp.LastName) AS ProviderName, COUNT(*) AS UsageCount
FROM ServiceLogs s
INNER JOIN ServiceProvider sp ON s.ProviderId = sp.Id 
GROUP BY s.ServiceType
ORDER BY UsageCount DESC
LIMIT 1;


-- 2: Finding net pending payment per service provider
Select CONCAT(sp.FirstName,' ',sp.LastName) AS ProviderName, SUM(p.PaymentAmount) AS PendingAmount
From Payments p
INNER JOIN ServiceProvider sp ON p.ProviderId = sp.Id
Where p.PaymentStatus = 'Pending'
GROUP BY ProviderName;


-- 3: Find all bills for a given employee 
Select  CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
		 CONCAT(sp.FirstName,' ',sp.LastName) AS ProviderName,
         p.TranscationMonth,
         p.TranscationYear,
         sp.ServiceType,
         p.PaymentAmount,
         p.PaymentStatus
From Payments p 
Inner JOIN Employees e ON p.EmployeeId = e.Id
Inner JOIN ServiceProvider sp ON p.ProviderId = sp.Id
Order by CONCAT(e.FirstName,' ',e.LastName);


