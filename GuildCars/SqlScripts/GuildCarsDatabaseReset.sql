USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GuildCarsDbReset')
      DROP PROCEDURE GuildCarsDbReset
GO

CREATE PROCEDURE GuildCarsDbReset AS
BEGIN
	DELETE FROM PurchaseLog;
	DELETE FROM Cars;
	DELETE FROM BodyStyle;
	DELETE FROM Model;
	DELETE FROM Color;
	DELETE FROM CustomerContact;
	DELETE FROM Make;
	DELETE FROM Specials;
	DELETE FROM Transmission;
	DELETE FROM AspNetUsers WHERE Id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111',
	'22222222-2222-2222-2222-222222222222', '33333333-3333-3333-3333-333333333333', 'Added-Test-User');
	

	DBCC CHECKIDENT ('Cars', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)
	DBCC CHECKIDENT ('Model', RESEED, 1)
	DBCC CHECKIDENT ('CustomerContact', RESEED, 1)
	DBCC CHECKIDENT ('PurchaseLog', RESEED, 1)
	DBCC CHECKIDENT ('Specials', RESEED, 1)

	SET IDENTITY_INSERT BodyStyle ON;

	INSERT INTO BodyStyle(BodyStyleId, BodyStyleType)
	VALUES(1, 'Truck'),
	(2, 'Car'),
	(3, 'SUV'),
	(4, 'Van')
	
	SET IDENTITY_INSERT BodyStyle OFF;

	SET IDENTITY_INSERT Color ON;

	INSERT INTO Color(ColorId, ColorName)
	VALUES(1, 'Black'),
	(2, 'Silver'),
	(3, 'Gray'),
	(4, 'Tan'),
	(5,	'White')

	SET IDENTITY_INSERT Color OFF;

	SET IDENTITY_INSERT Transmission ON;

	INSERT INTO Transmission(TransmissionId, TransmissionType)
	VALUES(1, 'Automatic'),
	(2, 'Manual')

	SET IDENTITY_INSERT Transmission OFF;

	SET IDENTITY_INSERT Make ON;

	INSERT INTO Make(MakeId, MakeName, DateAdded)
	VALUES(1, 'Toyota', '7/19/2017'),
	(2, 'Acura', '7/2/2017'),
	(3, 'Ford', '6/2/2015'),
	(4, 'Dodge', '5/1/2009')
	
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;

	INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded)
	VALUES(1, 'Tundra LX', 1, '7/19/2017' ),
	(2, 'Escape', 3, '6/2/2015'),
	(3, 'TLX', 2, '7/2/2017'),
	(4, 'Grand Caravan', 4, '5/1/2009')
	
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT Cars ON;

	INSERT INTO Cars(CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails )
	VALUES (1, CONVERT(DATE, '1/1/2017'), 'true', 'false', 'true', 3, 0, '1ABC1ABC1ABC1ABC1', 1, 1, 1, 1, 1, 1, 50315.00, 51815.00, '/Images/2017ToyotaTundra1794.jpg', 'Brand New and looks great.' ),
	(2, CONVERT(DATE, '1/1/2018'), 'true', 'true', 'false', 5, 200, '2ABC2ABC2ABC2ABC2', 2, 2, 2, 2, 3, 3, 33000, 34150, '/Images/2018AcuraTLX.png', 'A silver bullet of power and dependability.' ),
	(3, CONVERT(DATE, '1/1/2017'), 'false', 'true', 'true', 1, 1200, '3ABC3ABC3ABC3ABC3', 5, 3, 1, 3, 2, 5, 22669, 24500, '/Images/2017FordEscape.png', 'Loaded! Used Price for Brand New Quality.' ),
	(4, CONVERT(DATE, '1/1/2005'), 'false', 'false', 'false', 1, 111200, '4ABC4ABC4ABC4ABC4', 5, 4, 1, 4, 4, 4, 4000.00, 5000.00, '/Images/2005DodgeGrandCaravan.jpg', 'Certified and ready to take your family anywhere.' ),
	(5, CONVERT(DATE, '1/1/2017'), 'true', 'true', 'false', 5, 0, '5ABC5ABC5ABC5ABC5', 2, 2, 2, 2, 3, 3, 10000, 10000, '/Images/MockNewCarPhoto.jpg', 'New Car Mock Data 5' ),
	(6, CONVERT(DATE, '1/1/2017'), 'true', 'true', 'false', 1, 0, '6ABC6ABC6ABC6ABC6', 5, 3, 1, 3, 2, 5, 10000, 10000, '/Images/MockNewCarPhoto.jpg', 'New Car Mock Data 6' ),
	(7, CONVERT(DATE, '1/1/2017'), 'true', 'true', 'false', 1, 0, '7ABC7ABC7ABC7ABC7', 5, 4, 1, 4, 4, 4, 10000, 10000, '/Images/MockNewCarPhoto.jpg', 'New Car Mock Data 7' ),
	(8, CONVERT(DATE, '1/1/2017'), 'false', 'true', 'false', 5, 0, '8ABC8ABC8ABC8ABC8', 2, 2, 2, 2, 3, 3, 10000, 10000, '/Images/MockUsedCarPhoto.jpg', 'UsedCar Mock Data 8' ),
	(9, CONVERT(DATE, '1/1/2017'), 'false', 'true', 'false', 1, 0, '9ABC9ABC9ABC9ABC9', 5, 3, 1, 3, 2, 5, 10000, 10000, '/Images/MockUsedCarPhoto.jpg', 'Used Car Mock Data 9' ),
	(10, CONVERT(DATE, '1/1/2017'), 'false', 'true', 'false', 1, 0, '10ABC10ABC10ABC10ABC10', 5, 4, 1, 4, 4, 4, 10000, 10000, '/Images/MockUsedCarPhoto.jpg', 'Used Car Mock Data 10' )
	
	SET IDENTITY_INSERT Cars OFF;

	

	SET IDENTITY_INSERT CustomerContact ON;

	INSERT INTO CustomerContact(ContactId, ContactName, MessageBody, Phone, Email)
	VALUES(1, 'Test Contact 1', 'Test Contact Message 1', '555-555-5555', 'test1@test.com'),
	(2, 'Test Contact 2', 'Test Contact Message 2', '777-777-7777', 'test2@test.com'),
	(3, 'Test Contact 3', 'Test Contact Message 3', '111-111-1111', 'test3@test.com')
	
	SET IDENTITY_INSERT CustomerContact OFF;

	-- Test Users

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, UserRole)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'sales1@test.com', 0, 0, 0, 'Sales Test User 1', 'Disabled');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, UserRole)
	VALUES('11111111-1111-1111-1111-111111111111', 0, 0, 'sales2@test.com', 0, 0, 0, 'Sales Test User 2', 'Sales');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, UserRole)
	VALUES('22222222-2222-2222-2222-222222222222', 0, 0, 'admin1@test.com', 0, 0, 0, 'Admin Test User 1', 'Admin');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, UserRole)
	VALUES('33333333-3333-3333-3333-333333333333', 0, 0, 'admin2@test.com', 0, 0, 0, 'Admin Test User 2', 'Admin');

	SET IDENTITY_INSERT PurchaseLog ON;

	INSERT INTO PurchaseLog(PurchaseLogId, PurchaserName, DateSold, CarId, SalesPersonId, PurchasePrice,
	PurchaseType, Phone, Email, AddressOne, AddressTwo, City, ZipCode)
	VALUES(1, 'Purchaser One', '1/1/2017', 1, '00000000-0000-0000-0000-000000000000', 
	17000, 'Dealer Finance', '000-000-0000', 'testpurchase1@test.com', '123 Main Street',
	NULL, 'Hampton', '23652'),
	(2, 'Purchaser Two', '1/1/2016', 4, '11111111-1111-1111-1111-111111111111',
	4000, 'Dealer Finance', '111-111-1111', 'testpurchase2@test.com', '123 Elm Street', 
	'Apartment 33D', 'York', '23692'),
	(3, 'Purchaser Three', '4/1/2017', 3, '00000000-0000-0000-0000-000000000000', 
	10000, 'Dealer Finance', '000-000-0000', 'testpurchase3@test.com', '123 Odd Street',
	NULL, 'Hampton', '23652'),
	(4, 'Purchaser Four', '1/1/2016', 1, '11111111-1111-1111-1111-111111111111',
	14000, 'Dealer Finance', '111-111-1111', 'testpurchase4@test.com', '123 Elm Street', 
	'Apartment 33D', 'York', '23692')

	SET IDENTITY_INSERT PurchaseLog OFF;

	SET IDENTITY_INSERT Specials ON;

	INSERT INTO Specials(SpecialsId, SpecialDetails, Title)
	VALUES(1, '$1000 Rebate on Toyota SUVs!', '$1000 Rebate Special!'),
	(2, 'Free tank of gas with every purchase!', 'Free tank of gas!'),
	(3, 'Free extended warranty on all Ford models!', 'Ford free warranty special'),
	(4, '1% Financing special all Summer Long!', '1% Financing special')
	
	SET IDENTITY_INSERT Specials OFF;

	END

	