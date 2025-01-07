-- COMPLEX QUERIS WITH SUB QUERIS:

-- SUMMARZIZE DATA:
SELECT 
	'Bill in Financial Year 2023' AS Financial_Year,
	MAX(PaymentAmount) AS Higest_Bill,
    MIN(PaymentAmount) AS Lowest_Bill,
	AVG(PaymentAmount) AS AVG_Bill, -- WE CAN GIVE EXPRESSION TO AGGREAGATE FUNCITONS AS WELL LIKE (COLM * 20 )
    SUM(PaymentAmount) AS TOTAL_BILL_TO_RKIT, -- all these takes only non null values
    COUNT(*) AS Total_RECORDS
FROM Payments								-- HOWEVER MAIN RESULT IS GET FROM FILETER IN WHERE
WHERE PaymentStatus = 'Pending'
AND TranscationYear BETWEEN 2020 AND 2023

UNION -- used to club output of two query Hoever the column type must be same

SELECT 
	'Bill in Financial Year 2024' AS Financial_Year,
	MAX(PaymentAmount) AS Higest_Bill,
    MIN(PaymentAmount) AS Lowest_Bill,
	AVG(PaymentAmount) AS AVG_Bill, -- WE CAN GIVE EXPRESSION TO AGGREAGATE FUNCITONS AS WELL LIKE (COLM * 20 )
    SUM(PaymentAmount) AS TOTAL_BILL_TO_RKIT, -- all these takes only non null values
    COUNT(*) AS Total_RECORDS
FROM Payments								-- HOWEVER MAIN RESULT IS GET FROM FILETER IN WHERE
WHERE PaymentStatus = 'Pending'
AND TranscationYear BETWEEN 2024 AND 2025;
