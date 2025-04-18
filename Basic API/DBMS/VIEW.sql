-- View :
			-- Simple view 
				-- does not have GROUP BY, HAVING, or JOIN operations.
				--  non-updatable, meaning you cannot modify the underlying data through the view.
			-- Complex view
                -- using JOIN operations, or applying GROUP BY and HAVING clauses
                
-- indexed and materialized view are not supported by MYsql
        

-- A QUERY TO SEE ALL BILLS
CREATE VIEW SHOW_BILLs AS
SELECT 
    CONCAT(sp.FirstName, ' ', sp.LastName) AS ServiceProvider_Name,
    CONCAT(e.FirstName, ' ', e.LastName) AS Employee_Name,
    sp.ServiceType AS Service,
    p.TranscationMonth AS Transaction_Month,
    p.TranscationYear AS Transaction_Year,
    p.PaymentAmount,
    p.PaymentStatus
FROM 
    Payments p
INNER JOIN 
    ServiceProvider sp ON p.ProviderId = sp.Id
INNER JOIN 
    Employees e ON p.EmployeeId = e.Id;
 
 
 SELECT * FROM SHOW_BILLs;
 
 DROP VIEW SHOW_BILLs;
 
 