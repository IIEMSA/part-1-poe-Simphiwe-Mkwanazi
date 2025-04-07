USE master;

-- Drop database if it exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventCaseDB')
BEGIN
    ALTER DATABASE EventCaseDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EventCaseDB;
END

-- Create the new database
CREATE DATABASE EventCaseDB;

-- Switch to the new database
USE EventCaseDB;

-- Venue Table
CREATE TABLE Venue (
    Venue_ID INT IDENTITY(1,1) PRIMARY KEY,
    Venue_Name VARCHAR(350) NOT NULL,
    Location VARCHAR(350) NOT NULL,
    Capacity INT NOT NULL,
    Image_Url VARCHAR(500)
);

-- Insert venue data
INSERT INTO Venue (Venue_Name, Location, Capacity, Image_Url)
VALUES ('iie msa', 'Cape Town', 100000, 'http://example.com/venue-image.jpg');

-- Event Table
CREATE TABLE Event (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(350) NOT NULL,
    EventDate DATE NOT NULL,
    Description VARCHAR(MAX),
    VenueID INT NULL,
    FOREIGN KEY (VenueID) REFERENCES Venue(Venue_ID)
);

-- Insert event data (uses Venue_ID = 1)
INSERT INTO Event (EventName, EventDate, Description, VenueID)
VALUES ('God did', '2024-11-18', 'Ah Neh On', 1);

-- Booking Table
CREATE TABLE Booking (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    EventID INT NOT NULL,
    VenueID INT NOT NULL,
    BookingDate DATE NOT NULL,
    CONSTRAINT UQ_Booking UNIQUE (EventID, VenueID),
    FOREIGN KEY (EventID) REFERENCES Event(EventID),
    FOREIGN KEY (VenueID) REFERENCES Venue(Venue_ID)
);

-- Insert booking data (EventID = 1, VenueID = 1)
INSERT INTO Booking (EventID, VenueID, BookingDate)
VALUES (1, 1, '2025-05-10');

-- Verify all data
SELECT * FROM Booking;
SELECT * FROM Venue;
SELECT * FROM Event;