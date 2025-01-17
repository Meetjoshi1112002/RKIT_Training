DELIMITER $$

CREATE PROCEDURE demo(empId INT, OUT output TEXT)
BEGIN
    DECLARE emp_name TEXT;

    -- Get the employee's first name
    SELECT FirstName INTO emp_name FROM Employees WHERE Id = empId;
    
    -- Check the employee's name and set output accordingly
    IF emp_name = 'Meet' THEN
        SET output = 'high_money';
    ELSE
        SET output = 'low_salary';
    END IF;
END $$

DELIMITER ;

CALL demo(1, @result);
SELECT @result;


CREATE PROCEDURE update_service_logs (
    IN p_provider_id INT,
    IN p_employee_id INT,
    IN p_transaction_month INT,
    IN p_transaction_year INT
)
BEGIN
    UPDATE ServiceLogs
    SET PaymentStatus = 'Paid'
    WHERE ProviderId = p_provider_id
    AND EmployeeId = p_employee_id
    AND MONTH(ServingDate) = p_transaction_month
    AND YEAR(ServingDate) = p_transaction_year;
END $$

DELIMITER ;
