-- TRANSACITON 
		-- ACID PROPERTY
        -- ATOMICITY
        -- CONSISTANCY
        -- ISOLATION  (MULTIPLE TRANSACTION SHOULD NOT INTERFERE WITH EACH OTHER) THERE SHOULD BE MUTAL EXCLUSION
        -- DURABLITY  (CHANGES MADE BY TRANSACTION SHOULD PERSISTS


-- CREATE TRANSACTION:
START TRANSACTION;
		INSERT INTO ServiceLogs (ProviderId, EmployeeId,ServiceType, SubServiceType, Price, Quantity, ServingDate, ServingTime, PaymentStatus)
		VALUES
		(1,1, 'Beverages', 'Tea', 10, 50, '2023-12-01', '10:00:00', 'Pending');
		SAVEPOINT LOG_CREATED;
        
        -- we add to bill only after a log is created
		UPDATE Payments
        SET PaymentAmount = PaymentAmount + 500
        WHERE ProviderId = 1
        AND TranscationMonth = 12
        AND TranscationYear = 23
        AND EmployeeId = 1;
        SAVEPOINT ADDED_LOG_TO_BILL;
		-- rollback for manual rollback
COMMIT;


-- CONCURANCY AND LOCKING:
		-- LOST UPDATES
        -- HOWEVER THIS IS HANDLED BY TRANSACTION ITSELF 
        -- WHILE ONE TRANSACTION IS RUNING OVER SOME RESOURCES THAT RESOURCES ARE LOCKED FOR SOMETIME
        
        -- DIRTY READ
        -- A TRANS MAKE UPDATE 20 BEFORE COMMIT, AND B READS 20 AND MAKE A DECISION BUT A ROLLBACK
        -- SO HERE B MADE DIRTY READ
        -- HANDLED BY INCREASING THE ISOLATION LEVEL TO *READ COMMITED*
        -- HERE B WILL READ ONLY COMMITED TRANCATIONS (BUT MAY HAVE NON REPEATING READ PROBLEM)
        
        -- NON REAPEATING READ (A , B ARE TRANSACTIONS)
        -- OCCURS WHEN A READ VALUE 10 --> B UPDATE THE VALUE TO 20 WHILE A YET RUNNING --> THEN A DURING SAME TRANS READ 20 SO IT WILL BE CONFUSED
        -- IN SUCH CASES, WE INCREASE THE ISOLATION LEVEL OF OUR TRANSACTION TO *REPEATABLE READ*
        -- *REPEATABLE READ* ENSURE A TRANACTION READ SAME VALUE OF RESORUCE DURING ENTIRE LIFETIME
        
        -- PHANTOM READ (A NEW RECORD IS CREATED BY SOME OTHER TRANSACTION IS NOT VISIBLE TO THIS ONE)
        -- SUCH CASE MAKE THE ISOLATION LEVEL SERIALZABLE 
        -- IF ANY OTHER TRANSACTIO IS GOING ON THAT THAT SERIZALZBLE TRANSACITON WILL HAVE TO WAIT!
        -- IT IS RARE AND DEPENDS ON BUSSINESS LOGIC AS WELL
        
        
        -- ISOLATION LEVEL:
		-- DEFAULT IS : *REPEATABLE READ*
        -- HIGHER THE ISOLATION MORE CONCURANCY
        -- HIGHER THE ISOLATION LOWER THE PERFORMACE

-- CHECK CURRENT ISOLATION 
SHOW VARIABLES LIKE 'transaction_isolation';

-- SET TO OTHER LEVEL
SET TRANSACTION ISOLATION LEVEL serializable;
-- USE GLOBAL/SESSION DEPENDING ON NEED
