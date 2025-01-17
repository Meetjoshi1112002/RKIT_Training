CREATE DATABASE IF NOT EXISTS orm_demo_mj;

USE OfficeOpsDB;

-- Employees of RKIT
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender ENUM('Male', 'Female', 'Others') NOT NULL,
    PhoneNumber VARCHAR(20) UNIQUE
);

-- External service providers not belonging to RKIT
CREATE TABLE ServiceProvider (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    Gender ENUM('Male', 'Female', 'Others') NOT NULL,
    PhoneNumber VARCHAR(20) UNIQUE,
    ServiceType ENUM('Beverages', 'Water', 'Cleaning') NOT NULL,
    CompanyName VARCHAR(20) NOT NULL
);

-- Consolidated service logs for all services provided by comapany
CREATE TABLE ServiceLogs (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProviderId INT NOT NULL,
    EmployeeId INT NOT NULL,
    ServiceType ENUM('Beverages', 'Water', 'Cleaning') NOT NULL,
    SubServiceType ENUM("Tea","Coffee","Regular", "Special","Jug","Cargo") NOT NULL,
    Price INT NOT NULL,
    Quantity INT NOT NULL, -- Not for cleaning
    ServingDate DATE NOT NULL,
    ServingTime TIME NOT NULL,
    PaymentStatus ENUM('Paid', 'Pending') DEFAULT 'Pending',
    FOREIGN KEY (ProviderId) REFERENCES ServiceProvider(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

CREATE TABLE Payments (
    -- ServiceType ENUM('Beverages', 'Water', 'Cleaning') NOT NULL,
    ProviderId INT NOT NULL,
    TranscationMonth INT NOT NULL, -- Like January, February, etc.
    TranscationYear INT NOT NULL,
    PaymentAmount INT NOT NULL,
    PaymentStatus ENUM('Paid', 'Pending') DEFAULT 'Pending',
    PaymentTime TIMESTAMP DEFAULT NULL,
    EmployeeId INT NOT NULL,
    PRIMARY KEY (ProviderId, TranscationMonth, TranscationYear, EmployeeId), -- Correct column name
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id), 
    FOREIGN KEY (ProviderId) REFERENCES ServiceProvider(Id) 
);

