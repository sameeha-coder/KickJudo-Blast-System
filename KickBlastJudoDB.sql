-- =============================================
-- KICKBLAST JUDO COMPLETE SYSTEM DATABASE
-- Activity 4 - Full Implementation
-- =============================================

USE master;
GO

-- Drop existing database if exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'KickBlastJudoDB')
BEGIN
    ALTER DATABASE KickBlastJudoDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE KickBlastJudoDB;
END
GO

-- Create fresh database
CREATE DATABASE KickBlastJudoDB;
GO

USE KickBlastJudoDB;
GO

-- =============================================
-- TABLE 1: Users (Login System)
-- =============================================
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Role VARCHAR(20) DEFAULT 'Staff',
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastLogin DATETIME NULL
);
GO

-- =============================================
-- TABLE 2: Athletes (Main Registration Table)
-- =============================================
CREATE TABLE Athletes (
    AthleteID INT PRIMARY KEY IDENTITY(1001,1), -- Start from 1001 for better ID
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age AS (DATEDIFF(YEAR, DateOfBirth, GETDATE())), -- Calculated column
    Gender VARCHAR(10) NOT NULL,
    ContactNumber VARCHAR(15) NOT NULL,
    Email VARCHAR(100),
    Address VARCHAR(255),
    EmergencyContactName VARCHAR(100) NOT NULL,
    EmergencyContactPhone VARCHAR(15) NOT NULL,
    EnrollmentDate DATE DEFAULT CAST(GETDATE() AS DATE),
    IsActive BIT DEFAULT 1,
    CreatedBy VARCHAR(50),
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLE 3: TrainingPlans (Reference/Lookup Table)
-- =============================================
CREATE TABLE TrainingPlans (
    PlanID INT PRIMARY KEY IDENTITY(1,1),
    PlanName VARCHAR(50) NOT NULL UNIQUE,
    SessionsPerWeek INT NOT NULL,
    WeeklyFee DECIMAL(10,2) NOT NULL,
    MonthlyFee AS (WeeklyFee * 4), -- Calculated column
    CanCompete BIT NOT NULL,
    Description VARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLE 4: WeightCategories (Reference/Lookup Table)
-- =============================================
CREATE TABLE WeightCategories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL UNIQUE,
    UpperWeightLimit DECIMAL(5,2) NOT NULL,
    GenderApplicable VARCHAR(10) DEFAULT 'Both',
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLE 5: MonthlyRegistrations (Fee Calculation & Storage)
-- =============================================
CREATE TABLE MonthlyRegistrations (
    RegistrationID INT PRIMARY KEY IDENTITY(5001,1), -- Unique monthly fee ID
    AthleteID INT NOT NULL,
    PlanID INT NOT NULL,
    CategoryID INT NOT NULL,
    RegistrationMonth DATE NOT NULL,
    CurrentWeight DECIMAL(5,2) NOT NULL,
    NumCompetitions INT DEFAULT 0,
    PrivateCoachingHours DECIMAL(4,1) DEFAULT 0,
    TrainingPlanCost DECIMAL(10,2) NOT NULL,
    CompetitionCost DECIMAL(10,2) DEFAULT 0,
    PrivateCoachingCost DECIMAL(10,2) DEFAULT 0,
    TotalMonthlyCost DECIMAL(10,2) NOT NULL,
    WeightStatus VARCHAR(100),
    PaymentStatus VARCHAR(20) DEFAULT 'Pending',
    Notes VARCHAR(500),
    CreatedBy VARCHAR(50),
    RegistrationDate DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME DEFAULT GETDATE(),
    
    -- Foreign Keys
    CONSTRAINT FK_MonthlyReg_Athlete FOREIGN KEY (AthleteID) 
        REFERENCES Athletes(AthleteID) ON DELETE CASCADE,
    CONSTRAINT FK_MonthlyReg_Plan FOREIGN KEY (PlanID) 
        REFERENCES TrainingPlans(PlanID),
    CONSTRAINT FK_MonthlyReg_Category FOREIGN KEY (CategoryID) 
        REFERENCES WeightCategories(CategoryID),
    
    -- Constraints
    CONSTRAINT CHK_Competitions CHECK (NumCompetitions >= 0),
    CONSTRAINT CHK_PrivateHours CHECK (PrivateCoachingHours >= 0 AND PrivateCoachingHours <= 20),
    CONSTRAINT CHK_PaymentStatus CHECK (PaymentStatus IN ('Pending', 'Paid', 'Overdue'))
);
GO

-- =============================================
-- CREATE INDEXES FOR PERFORMANCE
-- =============================================
CREATE INDEX IX_Athletes_Name ON Athletes(LastName, FirstName);
CREATE INDEX IX_Athletes_Active ON Athletes(IsActive);
CREATE INDEX IX_MonthlyReg_Month ON MonthlyRegistrations(RegistrationMonth);
CREATE INDEX IX_MonthlyReg_Athlete ON MonthlyRegistrations(AthleteID);
GO

-- =============================================
-- CREATE VIEW: Complete Athlete Profile
-- =============================================
CREATE VIEW vw_AthleteProfile AS
SELECT 
    a.AthleteID,
    CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
    a.FirstName,
    a.LastName,
    a.DateOfBirth,
    a.Age,
    a.Gender,
    a.ContactNumber,
    a.Email,
    a.Address,
    a.EmergencyContactName,
    a.EmergencyContactPhone,
    a.EnrollmentDate,
    a.IsActive,
    COUNT(mr.RegistrationID) AS TotalRegistrations
FROM Athletes a
LEFT JOIN MonthlyRegistrations mr ON a.AthleteID = mr.AthleteID
GROUP BY 
    a.AthleteID, a.FirstName, a.LastName, a.DateOfBirth, 
    a.Age, a.Gender, a.ContactNumber, a.Email, a.Address,
    a.EmergencyContactName, a.EmergencyContactPhone, 
    a.EnrollmentDate, a.IsActive;
GO

-- =============================================
-- CREATE VIEW: Monthly Fee Details
-- =============================================
CREATE VIEW vw_MonthlyFeeDetails AS
SELECT 
    mr.RegistrationID AS FeeID,
    mr.AthleteID,
    CONCAT(a.FirstName, ' ', a.LastName) AS AthleteName,
    a.ContactNumber,
    tp.PlanName,
    tp.SessionsPerWeek,
    tp.MonthlyFee AS BaseFee,
    wc.CategoryName AS WeightCategory,
    wc.UpperWeightLimit,
    mr.RegistrationMonth,
    mr.CurrentWeight,
    mr.NumCompetitions,
    mr.PrivateCoachingHours,
    mr.TrainingPlanCost,
    mr.CompetitionCost,
    mr.PrivateCoachingCost,
    mr.TotalMonthlyCost,
    mr.WeightStatus,
    mr.PaymentStatus,
    mr.RegistrationDate,
    mr.CreatedBy
FROM MonthlyRegistrations mr
INNER JOIN Athletes a ON mr.AthleteID = a.AthleteID
INNER JOIN TrainingPlans tp ON mr.PlanID = tp.PlanID
INNER JOIN WeightCategories wc ON mr.CategoryID = wc.CategoryID;
GO

-- =============================================
-- INSERT DEFAULT DATA
-- =============================================

-- Insert Default Users
INSERT INTO Users (Username, Password, FullName, Role)
VALUES 
    ('admin', 'admin123', 'System Administrator', 'Admin'),
    ('staff1', 'staff123', 'John Wickramasinghe', 'Staff');
GO

-- Insert Training Plans
INSERT INTO TrainingPlans (PlanName, SessionsPerWeek, WeeklyFee, CanCompete, Description)
VALUES 
    ('Beginner', 2, 250.00, 0, 'Basic judo training for beginners - 2 sessions per week'),
    ('Intermediate', 3, 300.00, 1, 'Intermediate level training with competition eligibility - 3 sessions per week'),
    ('Elite', 5, 350.00, 1, 'Advanced training for elite athletes - 5 sessions per week');
GO

-- Insert Weight Categories
INSERT INTO WeightCategories (CategoryName, UpperWeightLimit, GenderApplicable)
VALUES 
    ('Flyweight', 66.00, 'Both'),
    ('Lightweight', 73.00, 'Both'),
    ('Light-Middleweight', 81.00, 'Both'),
    ('Middleweight', 90.00, 'Both'),
    ('Light-Heavyweight', 100.00, 'Both'),
    ('Heavyweight', 999.00, 'Both');
GO

-- Insert Sample Athletes
INSERT INTO Athletes (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Email, 
                     Address, EmergencyContactName, EmergencyContactPhone, CreatedBy)
VALUES 
    ('Kavindu', 'Silva', '2000-05-15', 'Male', '0771234567', 'kavindu@email.com', 
     '123 Main St, Colombo 05', 'Mrs. Nimal Silva', '0779876543', 'admin'),
    ('Saman', 'Perera', '1998-08-22', 'Male', '0762345678', 'saman@email.com', 
     '456 Park Road, Kandy', 'Mr. Sunil Perera', '0768765432', 'admin'),
    ('Sanduni', 'Fernando', '2001-03-18', 'Female', '0744567890', 'sanduni@email.com', 
     '789 Lake View, Galle', 'Mrs. Kamani Fernando', '0746543210', 'admin'),
    ('Dilshan', 'Rajapakse', '1999-07-25', 'Male', '0735678901', 'dilshan@email.com',
     '321 Beach Road, Negombo', 'Mr. Ravi Rajapakse', '0735432109', 'admin'),
    ('Chamari', 'Wickramasinghe', '2002-11-30', 'Female', '0726789012', 'chamari@email.com',
     '654 Hill Street, Matara', 'Mrs. Priya Wickramasinghe', '0724321098', 'admin'),
    ('Nimal', 'De Silva', '1995-12-10', 'Male', '0753456789', 'nimal@email.com',
     '987 Garden Lane, Jaffna', 'Mr. Kamal De Silva', '0757654321', 'admin');
GO

-- Insert Sample Monthly Registrations
INSERT INTO MonthlyRegistrations 
    (AthleteID, PlanID, CategoryID, RegistrationMonth, CurrentWeight, 
     NumCompetitions, PrivateCoachingHours, TrainingPlanCost, CompetitionCost, 
     PrivateCoachingCost, TotalMonthlyCost, WeightStatus, PaymentStatus, CreatedBy)
VALUES 
    (1001, 1, 2, '2025-10-01', 68.00, 0, 5.0, 1000.00, 0.00, 452.50, 
     1452.50, 'Athlete is in correct weight category.', 'Paid', 'admin'),
    (1002, 2, 4, '2025-10-01', 89.00, 2, 10.0, 1200.00, 440.00, 905.00, 
     2545.00, 'Athlete is in correct weight category.', 'Paid', 'admin'),
    (1003, 3, 6, '2025-10-01', 102.00, 3, 20.0, 1400.00, 660.00, 1810.00, 
     3870.00, 'Athlete is in correct weight category.', 'Pending', 'admin');
GO

-- =============================================
-- STORED PROCEDURE: Get Athlete Details by ID
-- =============================================
CREATE PROCEDURE sp_GetAthleteByID
    @AthleteID INT
AS
BEGIN
    SELECT 
        AthleteID,
        CONCAT(FirstName, ' ', LastName) AS FullName,
        FirstName,
        LastName,
        DateOfBirth,
        Age,
        Gender,
        ContactNumber,
        Email,
        Address,
        EmergencyContactName,
        EmergencyContactPhone,
        EnrollmentDate,
        IsActive
    FROM Athletes
    WHERE AthleteID = @AthleteID AND IsActive = 1;
END;
GO

-- =============================================
-- STORED PROCEDURE: Calculate and Save Monthly Fee
-- =============================================
CREATE PROCEDURE sp_SaveMonthlyRegistration
    @AthleteID INT,
    @PlanID INT,
    @CategoryID INT,
    @RegistrationMonth DATE,
    @CurrentWeight DECIMAL(5,2),
    @NumCompetitions INT,
    @PrivateCoachingHours DECIMAL(4,1),
    @TrainingPlanCost DECIMAL(10,2),
    @CompetitionCost DECIMAL(10,2),
    @PrivateCoachingCost DECIMAL(10,2),
    @TotalMonthlyCost DECIMAL(10,2),
    @WeightStatus VARCHAR(100),
    @CreatedBy VARCHAR(50)
AS
BEGIN
    INSERT INTO MonthlyRegistrations 
        (AthleteID, PlanID, CategoryID, RegistrationMonth, CurrentWeight, 
         NumCompetitions, PrivateCoachingHours, TrainingPlanCost, 
         CompetitionCost, PrivateCoachingCost, TotalMonthlyCost, 
         WeightStatus, CreatedBy)
    VALUES 
        (@AthleteID, @PlanID, @CategoryID, @RegistrationMonth, @CurrentWeight,
         @NumCompetitions, @PrivateCoachingHours, @TrainingPlanCost,
         @CompetitionCost, @PrivateCoachingCost, @TotalMonthlyCost, 
         @WeightStatus, @CreatedBy);
    
    SELECT SCOPE_IDENTITY() AS NewRegistrationID;
END;
GO

-- =============================================
-- STORED PROCEDURE: Update Monthly Registration
-- =============================================
CREATE PROCEDURE sp_UpdateMonthlyRegistration
    @RegistrationID INT,
    @CurrentWeight DECIMAL(5,2),
    @NumCompetitions INT,
    @PrivateCoachingHours DECIMAL(4,1),
    @TrainingPlanCost DECIMAL(10,2),
    @CompetitionCost DECIMAL(10,2),
    @PrivateCoachingCost DECIMAL(10,2),
    @TotalMonthlyCost DECIMAL(10,2),
    @WeightStatus VARCHAR(100)
AS
BEGIN
    UPDATE MonthlyRegistrations
    SET 
        CurrentWeight = @CurrentWeight,
        NumCompetitions = @NumCompetitions,
        PrivateCoachingHours = @PrivateCoachingHours,
        TrainingPlanCost = @TrainingPlanCost,
        CompetitionCost = @CompetitionCost,
        PrivateCoachingCost = @PrivateCoachingCost,
        TotalMonthlyCost = @TotalMonthlyCost,
        WeightStatus = @WeightStatus,
        ModifiedDate = GETDATE()
    WHERE RegistrationID = @RegistrationID;
END;
GO

-- =============================================
-- SUCCESS MESSAGE
-- =============================================
PRINT '========================================';
PRINT 'DATABASE CREATED SUCCESSFULLY!';
PRINT '========================================';
PRINT 'Database Name: KickBlastJudoDB';
PRINT '';
PRINT 'Tables Created: 5';
PRINT '  1. Users (Login system)';
PRINT '  2. Athletes (Registration)';
PRINT '  3. TrainingPlans (Reference)';
PRINT '  4. WeightCategories (Reference)';
PRINT '  5. MonthlyRegistrations (Fee calculator)';
PRINT '';
PRINT 'Views Created: 2';
PRINT 'Stored Procedures Created: 3';
PRINT '';
PRINT 'Default Login Credentials:';
PRINT '  Username: admin';
PRINT '  Password: admin123';
PRINT '';
PRINT 'Sample Data:';
PRINT '  - 2 Users';
PRINT '  - 6 Athletes (ID: 1001-1006)';
PRINT '  - 3 Training Plans';
PRINT '  - 6 Weight Categories';
PRINT '  - 3 Monthly Registrations';
PRINT '========================================';
GO