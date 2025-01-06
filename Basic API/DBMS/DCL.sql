CREATE USER MeetJoshi@'%.rkit.com' IDENTIFIED BY '12345';

-- Means john can connected any domain or subdomain of rkit
-- after @ we mention IP ffrom where user can connect
-- localhost means from same maching where sql server
-- so ideifine is the password

Select * from mysql.user;

DROP USER MeetJoshi@'%.rkit.com';
-- Remove the user when out of orangization

SET PASSWORD = '1234'; -- FOR CURRENLY LOG IN USER WE CAN UPDATE THE PASSWORD

SET PASSWORD FOR MEET = '121';
-- PASWORD CAN ALSO BE CHAGNED FROM ADMINSISTRAITON

-- PRIVILAGES
	-- CASE 1: WEB/DESKTOP USER FOR READ ONLY
    -- CASE 2: FOR A NEW ADMIN MORE THAN CASE 1 PRIVILAGES
CREATE USER APP_SAMPLE  IDENTIFIED BY '225';

		-- SYNTAX GRANT SELECT INSERT UPDATE DELETE EXECUTE
		-- ON DATABASE.TABLES

GRANT SELECT  -- ALL is highest level of privalleges
ON OfficeOpsDB.*
TO APP_SAMPLE;


-- SAMPLE HIGHEEST LEVEL 
GRANT ALL
ON *.*
TO APP_SAMPLE;


-- viewing grants (SAME CAN BE DONE FROM ADMINSITRATION)

SHOW GRANTS FOR APP_SAMPLE;

SHOW GRANTS; -- FOR CURRENT USER LOG IN


-- REVOKING PRIVIGAGERS

-- REVOKE ALL
-- ON *.*
-- FROM APP_SAMPLE;