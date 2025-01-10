Select FirstName
From Employees
Where Year(DateOfBirth) > '2000'; 

-- All employee whose first name start with alter A
-- % means anything in like
-- for regexp $ means end ^ means start
Select FirstName 
From Employees
Where FirstName Regexp '^[a-zA-Z]*t$';

-- Get the details of service logs for employees with Pending payment status, where the service type is either 'Beverages' or 'Water'. 
-- Limit the result to the top 5 entries, ordered by ServingDate in descending order.
Select e.FirstName, s.ServiceType, s.ServingDate, Sum(s.Price*s.Quantity )AS Amount
From ServiceLogs s 
Inner Join Employees e On s.EmployeeId = e.Id
Where s.ServiceType IN ("Beverages","Water")
And s.PaymentStatus = "Pending"
Group By e.FirstName,s.ServiceType
Having Amount > 200; -- filter after group by

-- Types of join:

-- Inner join : Return only matching ones
select e.FirstName, s.ServiceType
From Employees e INNER JOIN ServiceLogs s ON e.Id = s.EmployeeId;

-- Left join 
select e.FirstName, s.ServiceType
From Employees e Left JOIN ServiceLogs s ON e.Id = s.EmployeeId;

-- right join == left join for table on RHS
select e.FirstName, s.ServiceType
From Employees e Right JOIN ServiceLogs s ON e.Id = s.EmployeeId;

-- MYSQL doesnt support full join

-- Cross join multiply all of A with all of B in A cross B 
select e.FirstName, s.ServiceType
From Employees e cross JOIN ServiceLogs s ;

-- Self join: Used when rows are realted with each other
SELECT e1.FirstName, e2.FirstName
FROM Employees e1
CROSS JOIN Employees e2
WHERE e1.FirstName LIKE '%t'
AND e2.FirstName LIKE '%t'
AND e1.FirstName <= e2.FirstName -- this two conditions ensure m,n   n,m   n,n   m,m   are all one
AND e1.FirstName != e2.FirstName;

