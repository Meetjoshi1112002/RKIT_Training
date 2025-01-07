
-- ******************************************************************************************************************************************
DELIMITER $$

CREATE TRIGGER create_bill
AFTER INSERT ON ServiceLogs
FOR EACH ROW
BEGIN
    DECLARE existing_bill INT;

    -- Check if a payment record already exists for this provider, month, and year
    SELECT COUNT(*) INTO existing_bill
    FROM Payments
    WHERE ProviderId = NEW.ProviderId
    AND TranscationMonth = MONTH(NEW.ServingDate)
    AND TranscationYear = YEAR(NEW.ServingDate)
    AND EmployeeId = NEW.EmployeeId; 

    -- If no existing payment, insert a new one
    IF existing_bill = 0 THEN
        INSERT INTO Payments ( ProviderId, TranscationMonth, TranscationYear, PaymentAmount, PaymentStatus, PaymentTime, EmployeeId)
        VALUES (NEW.ProviderId, MONTH(NEW.ServingDate), YEAR(NEW.ServingDate), NEW.Price * NEW.Quantity, 'Pending', NULL, NEW.EmployeeId);
    -- If payment exists, update the amount
    ELSE
        UPDATE Payments
        SET PaymentAmount = PaymentAmount + (NEW.Price * NEW.Quantity)
        WHERE ProviderId = NEW.ProviderId
        AND TranscationMonth = MONTH(NEW.ServingDate)
        AND TranscationYear = YEAR(NEW.ServingDate)
        AND EmployeeId = NEW.EmployeeId;
    END IF;
END $$

DELIMITER ;

-- ******************************************************************************************************************************************

DELIMITER $$

CREATE TRIGGER update_logs
AFTER UPDATE ON Payments
FOR EACH ROW
BEGIN
   
	UPDATE ServiceLogs
	SET PaymentStatus = 'Paid'
	WHERE ProviderId = NEW.ProviderId
	AND EmployeeId = NEW.EmployeeId
	AND MONTH(ServingDate) = NEW.TranscationMonth
	AND YEAR(ServingDate) = NEW.TranscationYear;
END $$

DELIMITER ;

DROP TRIGGER update_logs;



