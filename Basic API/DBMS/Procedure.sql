DELIMITER $$

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
