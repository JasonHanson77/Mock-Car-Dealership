USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
BEGIN
	ALTER TABLE Model DROP CONSTRAINT FK_ModelMakeId;
	ALTER TABLE Cars DROP CONSTRAINT FK_MakeId;
	DROP TABLE Make
END
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
BEGIN
	ALTER TABLE Cars DROP CONSTRAINT FK_ModelId;
	DROP TABLE Model
END
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
BEGIN
	ALTER TABLE Cars DROP CONSTRAINT FK_TransmissionId;
	DROP TABLE Transmission
END
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
BEGIN
	ALTER TABLE Cars DROP CONSTRAINT FK_IntColorId;
	ALTER TABLE Cars DROP CONSTRAINT FK_BodyColorId;
	DROP TABLE Color
END
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
BEGIN
	ALTER TABLE Cars DROP CONSTRAINT FK_BodyStyleId;
	DROP TABLE BodyStyle
END
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CustomerContact')
	DROP TABLE CustomerContact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseLog')
	DROP TABLE PurchaseLog
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Cars')
	DROP TABLE Cars
GO

CREATE TABLE Make(
	MakeId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MakeName VARCHAR(15) NOT NULL,
	DateAdded DATETIME2 NOT NULL
)

CREATE TABLE Model(
	ModelId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ModelName VARCHAR(30) NOT NULL,
	MakeId INT NOT NULL CONSTRAINT FK_ModelMakeId FOREIGN KEY REFERENCES Make(MakeId),
	DateAdded DATETIME2 NOT NULL
)

CREATE TABLE Transmission(
	TransmissionId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TransmissionType VARCHAR(10)
)

CREATE TABLE Color(
	ColorId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ColorName VARCHAR(15)
)

CREATE TABLE BodyStyle(
	BodyStyleId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	BodyStyleType VARCHAR(25)
)

CREATE TABLE Cars(
	CarId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IsNew BIT NOT NULL,
	IsFeatured BIT NOT NUll,
	IsSold BIT NOT NULL,
	UnitsInStock INT NOT NULL,
	Mileage VARCHAR(7) NOT NULL,
	ModelYear INT NOT NULL,
	VIN VARCHAR(17) NOT NULL,
	BodyStyleId INT NOT NULL CONSTRAINT FK_BodyStyleId FOREIGN KEY REFERENCES BodyStyle(BodyStyleId),
	TransmissionId INT NOT NULL CONSTRAINT FK_TransmissionId FOREIGN KEY REFERENCES Transmission(TransmissionId),
	MakeId INT NOT NULL CONSTRAINT FK_MakeId FOREIGN KEY REFERENCES Make(MakeId),
	ModelId INT NOT NULL CONSTRAINT FK_ModelId FOREIGN KEY REFERENCES Model(ModelId),
	BodyColorId INT NOT NULL CONSTRAINT FK_BodyColorId FOREIGN KEY REFERENCES Color(ColorId),
	InteriorColorId INT NOT NULL CONSTRAINT FK_IntColorId FOREIGN KEY REFERENCES Color(ColorId), 
	SalePrice DECIMAL(7,2) NOT NULL,
	MSRP DECIMAL(7,2) NOT NULL,
	IMGFilePath NVARCHAR(MAX) NOT NULL,
	VehicleDetails NVARCHAR(400) NOT NULL
)

CREATE TABLE Specials(
	SpecialsId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SpecialDetails NVARCHAR(400) NOT NULL
)


CREATE TABLE PurchaseLog(
	PurchaseLogId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PurchaseType VARCHAR(16) NOT NULL,
	PurchaserName VARCHAR(40) NOT NULL,
	CarId INT NOT NULL CONSTRAINT FK_PurchasedCarId FOREIGN KEY REFERENCES Cars(CarId),
	AddressOne NVARCHAR(50)NOT NULL,
	AddressTwo NVARCHAR(50) NULL,
	City VARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NULL,
	Phone NVARCHAR(15) NULL,
	ZipCode VARCHAR(5) NOT NULL,
	PurchasePrice DECIMAL(10,2) NOT NULL,
	SalesPersonId NVARCHAR(128) NOT NULL CONSTRAINT FK_SalesPersonId FOREIGN KEY REFERENCES AspNetUsers(Id),
	DateSold DATETIME2 NOT NULL
)

CREATE TABLE CustomerContact(
	ContactId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ContactName VARCHAR(40) NOT NULL,
	MessageBody NVARCHAR(400) NOT NULL,
	Email NVARCHAR(50) NULL,
	Phone NVARCHAR(15) NULL,
)
