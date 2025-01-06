
# Data Definition Language Queries

# 1) DESCRIBE
DESCRIBE Payments;

# ----------------------------------------

# 2) EXPLAIN
EXPLAIN SELECT * FROM Payments WHERE PaymentAmount > 300 ORDER BY PaymentAmount DESC;

# ----------------------------------------

# 3) CREATE - already done

# ----------------------------------------

# 4) ALTER

# 4.1 - add column
ALTER TABLE ServiceLogs ADD Quantity INT;

# 4.2 - modify column
ALTER TABLE Payments MODIFY PaymentAmount FLOAT;

# 4.3 - rename column
ALTER TABLE Employees CHANGE DateOfBirth DOB DATE;

# 4.4 - drop a column
ALTER TABLE Employees DROP COLUMN LastName;

# 4.5 - add primary key
ALTER TABLE tbl_name ADD PRIMARY KEY (col_name);

# 4.6 - add unique
ALTER TABLE tbl_name ADD UNIQUE (col_name);

# 4.7 - add foreign key
ALTER TABLE tbl_name
ADD CONSTRAINT foreign_key_constraint_name  FOREIGN KEY (col_name)
REFERENCES tbl_name(col_name);

# 4.8 - drop primary key
ALTER TABLE tbl_name
DROP PRIMARY KEY;

# 4.9 - drop foreignn key
ALTER TABLE tbl_name
DROP FOREIGN KEY fkey_constraint_name;

# 4.10 - change table name
ALTER TABLE Employees
RENAME TO RKITians;

# ----------------------------------------

# 5) DROP - Permanently deletes table/database/view
DROP TABLE tbl_name;
DROP DATABASE dbase_name;
DROP VIEW view_name;

# ----------------------------------------


# 6) TRUNCATE - Removes all rows and reset autoincrement value. Preserve table structure.
TRUNCATE TABLE tbl_name;


ALTER TABLE ServiceLogs ADD Quantity INT;


DROP TABLE ServiceLogs;

DROP TABLE Address;

DROP TABLE Payments;

DROP TABLE ServiceProvider;

DROP TABLE Employees;

DROP TABLE PersonalBeverageService;

DROP TRIGGER IF EXISTS update_logs;

DROP TRIGGER IF EXISTS log_payment_for_personal_beverage;


DROP TRIGGER IF EXISTS update_payment_and_services;

DROP TRIGGER IF EXISTS  validate_address_entity;

Drop database officeopsdb;
