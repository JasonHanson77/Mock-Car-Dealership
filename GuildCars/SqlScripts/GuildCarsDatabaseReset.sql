USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GuildCarsDbReset')
      DROP PROCEDURE GuildCarsDbReset
GO

CREATE PROCEDURE GuildCarsDbReset AS
BEGIN
	DELETE FROM Cars;
	DELETE FROM BodyStyle;
	DELETE FROM Model;
	DELETE FROM Color;
	DELETE FROM CustomerContact;
	DELETE FROM Make;
	DELETE FROM PurchaseLog;
	DELETE FROM Specials;
	DELETE FROM Transmission;

	DBCC CHECKIDENT ('Cars', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)
	DBCC CHECKIDENT ('Model', RESEED, 1)

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
	VALUES (1, 2017, 'true', 'false', 'true', 3, 0, '1ABC1ABC1ABC1ABC1', 1, 1, 1, 1, 3, 1, 50315.00, 51815.00, 'Images\2017ToyotaTundra1794.jpg', 'Brand New and looks great.' ),
	(2, 2018, 'true', 'true', 'false', 5, 200, '2ABC2ABC2ABC2ABC2', 2, 2, 2, 2, 3, 3, 33000, 34150, 'Images\2018AcuraTLX.png', 'A silver bullet of power and dependability.' ),
	(3, 2017, 'false', 'true', 'true', 1, 1200, '3ABC3ABC3ABC3ABC3', 5, 3, 1, 3, 1, 5, 22669, 24500, 'Images\2017FordEscape.png', 'Loaded! Used Price for Brand New Quality.' ),
	(4, 2005, 'false', 'false', 'false', 1, 111200, '4ABC4ABC4ABC4ABC4', 5, 4, 1, 4, 4, 4, 4000.00, 5000.00, 'Images\2005DodgeGrandCaravan.jpg', 'Certified and ready to take your family anywhere.' )

	SET IDENTITY_INSERT Cars OFF;
END

