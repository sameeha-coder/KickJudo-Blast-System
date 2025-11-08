-- KickBlast Judo Database Structure
-- Created for Activity 3 - Database Design
-- Fixed for SQL Server Management Studio 2021

USE master;
GO

-- Drop database if exists (for clean installation)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'KickBlastJudoDB')
BEGIN
    ALTER DATABASE KickBlastJudoDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE KickBlastJudoDB;
END
GO

-- Create database
CREATE DATABASE KickBlastJudoDB;
GO

USE KickBlastJudoDB;
GO

-- =============================================
-- Table 1: TrainingPlans
-- Stores training plan types and their costs
-- =============================================
CREATE TABLE TrainingPlans (
    PlanID INT PRIMARY KEY IDENTITY(1,1),
    PlanName VARCHAR(50) NOT NULL UNIQUE,
    SessionsPerWeek INT NOT NULL,
    WeeklyFee DECIMAL(10,2) NOT NULL,
    CanCompete BIT NOT NULL,
    Description VARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- Table 2: WeightCategories
-- Stores judo weight categories and limits
-- =============================================
CREATE TABLE WeightCategories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL UNIQUE,
    UpperWeightLimit DECIMAL(5,2) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- Table 3: Athletes
-- Stores athlete personal information
-- =============================================
CREATE TABLE Athletes (
    AthleteID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    ContactNumber VARCHAR(15),
    Email VARCHAR(100),
    Address VARCHAR(255),
    EmergencyContact VARCHAR(100),
    EmergencyPhone VARCHAR(15),
    EnrollmentDate DATE DEFAULT CAST(GETDATE() AS DATE),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- Table 4: MonthlyRegistrations
-- Records each athlete's monthly training details
-- =============================================
CREATE TABLE MonthlyRegistrations (
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
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
    RegistrationDate DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT FK_Registration_Athlete FOREIGN KEY (AthleteID) 
        REFERENCES Athletes(AthleteID),
    CONSTRAINT FK_Registration_Plan FOREIGN KEY (PlanID) 
        REFERENCES TrainingPlans(PlanID),
    CONSTRAINT FK_Registration_Category FOREIGN KEY (CategoryID) 
        REFERENCES WeightCategories(CategoryID),
    CONSTRAINT CHK_Competitions CHECK (NumCompetitions >= 0),
    CONSTRAINT CHK_PrivateHours CHECK (PrivateCoachingHours >= 0 AND PrivateCoachingHours <= 20)
);
GO

-- =============================================
-- Table 5: Payments
-- Tracks payment history for monthly fees
-- =============================================
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    RegistrationID INT NOT NULL,
    AthleteID INT NOT NULL,
    PaymentDate DATE NOT NULL,
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentMethod VARCHAR(50),
    PaymentStatus VARCHAR(20) DEFAULT 'Pending',
    TransactionReference VARCHAR(100),
    Notes VARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT FK_Payment_Registration FOREIGN KEY (RegistrationID) 
        REFERENCES MonthlyRegistrations(RegistrationID),
    CONSTRAINT FK_Payment_Athlete FOREIGN KEY (AthleteID) 
        REFERENCES Athletes(AthleteID),
    CONSTRAINT CHK_PaymentStatus CHECK (PaymentStatus IN ('Pending', 'Completed', 'Failed', 'Refunded'))
);
GO

-- =============================================
-- Insert Default Data
-- =============================================

-- Insert Training Plans
INSERT INTO TrainingPlans (PlanName, SessionsPerWeek, WeeklyFee, CanCompete, Description)
VALUES 
    ('Beginner', 2, 250.00, 0, 'Basic judo training for beginners - 2 sessions per week'),
    ('Intermediate', 3, 300.00, 1, 'Intermediate level training - 3 sessions per week'),
    ('Elite', 5, 350.00, 1, 'Advanced training for elite athletes - 5 sessions per week');
GO

-- Insert Weight Categories
INSERT INTO WeightCategories (CategoryName, UpperWeightLimit)
VALUES 
    ('Flyweight', 66.00),
    ('Lightweight', 73.00),
    ('Light-Middleweight', 81.00),
    ('Middleweight', 90.00),
    ('Light-Heavyweight', 100.00),
    ('Heavyweight', 999.00);
GO

-- Insert Sample Athletes (for testing)
INSERT INTO Athletes (FirstName, LastName, DateOfBirth, ContactNumber, Email, Address, EmergencyContact, EmergencyPhone)
VALUES 
    ('Kavindu', 'Silva', '2000-05-15', '0771234567', 'kavindu@email.com', '123 Main St, Colombo', 'Mrs. Silva', '0779876543'),
    ('Saman', 'Perera', '1998-08-22', '0762345678', 'saman@email.com', '456 Park Rd, Kandy', 'Mr. Perera', '0768765432'),
    ('Nimal', 'Fernando', '1995-12-10', '0753456789', 'nimal@email.com', '789 Lake View, Galle', 'Mrs. Fernando', '0757654321'),
    ('Sanduni', 'Wickramasinghe', '2001-03-18', '0744567890', 'sanduni@email.com', '321 Beach Rd, Negombo', 'Mr. Wickramasinghe', '0746543210'),
    ('Dilshan', 'Rajapakse', '1999-07-25', '0735678901', 'dilshan@email.com', '654 Hill St, Matara', 'Mrs. Rajapakse', '0735432109'),
    ('Chamari', 'De Silva', '2002-11-30', '0726789012', 'chamari@email.com', '987 Garden Lane, Jaffna', 'Mr. De Silva', '0724321098');
GO

-- Insert Sample Monthly Registrations
INSERT INTO MonthlyRegistrations (AthleteID, PlanID, CategoryID, RegistrationMonth, CurrentWeight, 
    NumCompetitions, PrivateCoachingHours, TrainingPlanCost, CompetitionCost, 
    PrivateCoachingCost, TotalMonthlyCost, WeightStatus)
VALUES 
    (1, 1, 2, '2025-10-01', 68.00, 0, 5.0, 1000.00, 0.00, 452.50, 1452.50, 'Athlete is in correct weight category.'),
    (2, 2, 4, '2025-10-01', 89.00, 2, 10.0, 1200.00, 440.00, 905.00, 2545.00, 'Athlete is in correct weight category.'),
    (3, 3, 6, '2025-10-01', 102.00, 3, 20.0, 1400.00, 660.00, 1810.00, 3870.00, 'Athlete is in correct weight category.');
GO

-- =============================================
-- Create Indexes for Better Performance
-- =============================================
CREATE INDEX IX_Athletes_Name ON Athletes(LastName, FirstName);
CREATE INDEX IX_Registration_Month ON MonthlyRegistrations(RegistrationMonth);
CREATE INDEX IX_Registration_Athlete ON MonthlyRegistrations(AthleteID);
CREATE INDEX IX_Payments_Date ON Payments(PaymentDate);
GO

-- =============================================
-- Create Views for Common Queries
-- =============================================

-- View: Complete Registration Details
CREATE VIEW vw_RegistrationDetails AS
SELECT 
    r.RegistrationID,
    a.AthleteID,
    CONCAT(a.FirstName, ' ', a.LastName) AS AthleteName,
    a.ContactNumber,
    tp.PlanName,
    tp.WeeklyFee,
    wc.CategoryName,
    wc.UpperWeightLimit,
    r.RegistrationMonth,
    r.CurrentWeight,
    r.NumCompetitions,
    r.PrivateCoachingHours,
    r.TrainingPlanCost,
    r.CompetitionCost,
    r.PrivateCoachingCost,
    r.TotalMonthlyCost,
    r.WeightStatus
FROM MonthlyRegistrations r
INNER JOIN Athletes a ON r.AthleteID = a.AthleteID
INNER JOIN TrainingPlans tp ON r.PlanID = tp.PlanID
INNER JOIN WeightCategories wc ON r.CategoryID = wc.CategoryID
WHERE a.IsActive = 1;
GO

-- View: Payment Summary
CREATE VIEW vw_PaymentSummary AS
SELECT 
    p.PaymentID,
    CONCAT(a.FirstName, ' ', a.LastName) AS AthleteName,
    r.RegistrationMonth,
    r.TotalMonthlyCost,
    p.AmountPaid,
    p.PaymentDate,
    p.PaymentStatus,
    p.PaymentMethod
FROM Payments p
INNER JOIN Athletes a ON p.AthleteID = a.AthleteID
INNER JOIN MonthlyRegistrations r ON p.RegistrationID = r.RegistrationID;
GO

-- =============================================
-- Stored Procedure: Calculate Monthly Fee
-- =============================================
CREATE PROCEDURE sp_CalculateMonthlyFee
    @AthleteID INT,
    @PlanID INT,
    @CategoryID INT,
    @CurrentWeight DECIMAL(5,2),
    @NumCompetitions INT,
    @PrivateCoachingHours DECIMAL(4,1),
    @RegistrationMonth DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TrainingPlanCost DECIMAL(10,2);
    DECLARE @CompetitionCost DECIMAL(10,2);
    DECLARE @PrivateCoachingCost DECIMAL(10,2);
    DECLARE @TotalCost DECIMAL(10,2);
    DECLARE @WeeklyFee DECIMAL(10,2);
    DECLARE @CanCompete BIT;
    DECLARE @WeightStatus VARCHAR(100);
    DECLARE @CategoryLimit DECIMAL(5,2);
    
    -- Get training plan details
    SELECT @WeeklyFee = WeeklyFee, @CanCompete = CanCompete
    FROM TrainingPlans WHERE PlanID = @PlanID;
    
    -- Calculate training plan cost (weekly fee × 4 weeks)
    SET @TrainingPlanCost = @WeeklyFee * 4;
    
    -- Check competition eligibility
    IF @CanCompete = 0 AND @NumCompetitions > 0
    BEGIN
        SET @NumCompetitions = 0;
    END
    
    -- Calculate competition cost
    SET @CompetitionCost = @NumCompetitions * 220.00;
    
    -- Validate and calculate private coaching (max 20 hours)
    IF @PrivateCoachingHours > 20
        SET @PrivateCoachingHours = 20;
    
    SET @PrivateCoachingCost = @PrivateCoachingHours * 90.50;
    
    -- Calculate total
    SET @TotalCost = @TrainingPlanCost + @CompetitionCost + @PrivateCoachingCost;
    
    -- Get weight category limit
    SELECT @CategoryLimit = UpperWeightLimit
    FROM WeightCategories WHERE CategoryID = @CategoryID;
    
    -- Determine weight status
    IF @CategoryLimit > 100
    BEGIN
        IF @CurrentWeight > 100
            SET @WeightStatus = 'Athlete is in correct weight category.';
        ELSE
            SET @WeightStatus = 'Athlete can increase weight to match category.';
    END
    ELSE
    BEGIN
        IF @CurrentWeight <= @CategoryLimit
            SET @WeightStatus = 'Athlete is in correct weight category.';
        ELSE
            SET @WeightStatus = 'Athlete needs to reduce weight.';
    END
    
    -- Insert registration
    INSERT INTO MonthlyRegistrations 
        (AthleteID, PlanID, CategoryID, RegistrationMonth, CurrentWeight, 
         NumCompetitions, PrivateCoachingHours, TrainingPlanCost, 
         CompetitionCost, PrivateCoachingCost, TotalMonthlyCost, WeightStatus)
    VALUES 
        (@AthleteID, @PlanID, @CategoryID, @RegistrationMonth, @CurrentWeight,
         @NumCompetitions, @PrivateCoachingHours, @TrainingPlanCost,
         @CompetitionCost, @PrivateCoachingCost, @TotalCost, @WeightStatus);
    
    -- Return the registration ID
    SELECT SCOPE_IDENTITY() AS RegistrationID, @TotalCost AS TotalMonthlyCost;
END;
GO

-- =============================================
-- Success Message
-- =============================================
PRINT 'Database KickBlastJudoDB created successfully!';
PRINT 'Total Tables Created: 5';
PRINT 'Total Views Created: 2';
PRINT 'Total Stored Procedures Created: 1';
PRINT '';
PRINT 'Sample data inserted:';
PRINT '  - 3 Training Plans';
PRINT '  - 6 Weight Categories';
PRINT '  - 6 Athletes';
PRINT '  - 3 Monthly Registrations';
PRINT '';
PRINT 'Database is ready to use!';
GO