USE GuildCars
GO

--Cars Repository Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllCars')
      DROP PROCEDURE SelectAllCars
GO

CREATE PROCEDURE SelectAllCars
AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllNewCars')
      DROP PROCEDURE SelectAllNewCars
GO

CREATE PROCEDURE SelectAllNewCars
AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
	WHERE IsNew = 'true'
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllUsedCars')
      DROP PROCEDURE SelectAllUsedCars
GO

CREATE PROCEDURE SelectAllUsedCars
AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
	WHERE IsNew = 'false'
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllUnsoldCars')
      DROP PROCEDURE SelectAllUnsoldCars
GO

CREATE PROCEDURE SelectAllUnsoldCars
AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
	WHERE IsSold = 'false'
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllSoldCars')
      DROP PROCEDURE SelectAllSoldCars
GO

CREATE PROCEDURE SelectAllSoldCars
AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
	WHERE IsSold = 'true'
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectCarById')
      DROP PROCEDURE SelectCarById
GO

CREATE PROCEDURE SelectCarById (
	@CarId INT
) AS
BEGIN
	SELECT CarId, ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails
	FROM Cars
	WHERE CarId = @CarId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CarDelete')
      DROP PROCEDURE CarDelete
GO

CREATE PROCEDURE CarDelete (
	@CarId int
) AS
BEGIN
	DELETE FROM Cars
	WHERE CarId = @CarId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CarInsert')
      DROP PROCEDURE CarInsert
GO

CREATE PROCEDURE CarInsert (
	@CarId INT OUTPUT,
	@ModelYear INT,
	@IsNew BIT,
	@IsFeatured BIT,
	@IsSold BIT,
	@UnitsInStock INT,
	@Mileage VARCHAR(7),
	@VIN VARCHAR(17),
	@BodyColorId INT,
	@BodyStyleId INT,
	@TransmissionId INT,
	@MakeId INT,
	@ModelId INT,
	@InteriorColorId INT,
	@SalePrice DECIMAL(7,2),
	@MSRP DECIMAL(7,2),
	@IMGFilePath NVARCHAR(MAX),
	@VehicleDetails NVARCHAR(400)
) AS
BEGIN
	INSERT INTO Cars(ModelYear, IsNew, IsFeatured, IsSold, UnitsInStock, Mileage, VIN, BodyColorId,
	BodyStyleId, TransmissionId, MakeId, ModelId, InteriorColorId, SalePrice, MSRP, IMGFilePath, VehicleDetails )
	VALUES (@ModelYear, @IsNew, @IsFeatured, @IsSold, @UnitsInStock, @Mileage, @VIN, @BodyColorId,
	@BodyStyleId, @TransmissionId, @MakeId, @ModelId, @InteriorColorId, @SalePrice, @MSRP, @IMGFilePath, @VehicleDetails)

	SET @CarId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CarUpdate')
      DROP PROCEDURE CarUpdate
GO

CREATE PROCEDURE CarUpdate (
	@CarId INT,
	@ModelYear INT,
	@IsNew BIT,
	@IsFeatured BIT,
	@IsSold BIT,
	@UnitsInStock INT,
	@Mileage VARCHAR(7),
	@VIN VARCHAR(17),
	@BodyColorId INT,
	@BodyStyleId INT,
	@TransmissionId INT,
	@MakeId INT,
	@ModelId INT,
	@InteriorColorId INT,
	@SalePrice DECIMAL(7,2),
	@MSRP DECIMAL(7,2),
	@IMGFilePath NVARCHAR(MAX),
	@VehicleDetails NVARCHAR(400)
) AS
BEGIN
	UPDATE Cars SET 
		ModelYear =	@ModelYear,
		IsNew = @IsNew,
		IsFeatured = @IsFeatured,
		IsSold = @IsSold,
		UnitsInStock = @UnitsInStock,
		Mileage = @Mileage,
		VIN = @VIN,
		BodyColorId = @BodyColorId,
		BodyStyleId = @BodyStyleId,
		TransmissionId = @TransmissionId,
		MakeId = @MakeId,
		ModelId =	@ModelId,
		InteriorColorId = @InteriorColorId,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		IMGFilePath = @IMGFilePath,
		VehicleDetails = @VehicleDetails
	WHERE CarId = @CarId
END

GO

--Body Style Repository Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllBodyStyles')
      DROP PROCEDURE SelectAllBodyStyles
GO

CREATE PROCEDURE SelectAllBodyStyles
AS
BEGIN
	SELECT BodyStyleId, BodyStyleType
	FROM BodyStyle
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectBodyStyleById')
      DROP PROCEDURE SelectBodyStyleById
GO

CREATE PROCEDURE SelectBodyStyleById(

@BodyStyleId INT

)AS
BEGIN
	SELECT BodyStyleId, BodyStyleType
	FROM BodyStyle
	WHERE BodyStyleId = @BodyStyleId 
END

GO

--Color Repository Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllColors')
      DROP PROCEDURE SelectAllColors
GO

CREATE PROCEDURE SelectAllColors
AS
BEGIN
	SELECT ColorId, ColorName
	FROM Color
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectColorById')
      DROP PROCEDURE SelectColorById
GO

CREATE PROCEDURE SelectColorById(

@ColorId INT

)AS
BEGIN
	SELECT ColorId, ColorName
	FROM Color
	WHERE ColorId = @ColorId 
END

GO

--Featured Listing Procedure

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectFeaturedCars')
      DROP PROCEDURE SelectFeaturedCars
GO

CREATE PROCEDURE SelectFeaturedCars(

@isFeatured BIT

)AS
BEGIN
	SELECT CarId, IMGFilePath, ModelYear, SalePrice, c.MakeId, c.ModelId, m.MakeName, mo.ModelName 
	FROM Cars c
		INNER JOIN Make m ON c.MakeId = m.MakeId
		INNER JOIN Model mo ON mo.MakeId = m.MakeId
	WHERE IsFeatured = @isFeatured
	ORDER BY CarId
END

GO

--Make Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllMakes')
      DROP PROCEDURE SelectAllMakes
GO

CREATE PROCEDURE SelectAllMakes
AS
BEGIN
	SELECT MakeId, MakeName, DateAdded
	FROM Make
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectMakeById')
      DROP PROCEDURE SelectMakeById
GO

CREATE PROCEDURE SelectMakeById(

@MakeId INT

)AS
BEGIN
	SELECT MakeId, MakeName
	FROM Make
	WHERE MakeId = @MakeId 
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
      DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeId INT OUTPUT,
	@MakeName VARCHAR(15),
	@DateAdded DATETIME2
	
) AS
BEGIN
	INSERT INTO Make(MakeName, DateAdded)
	VALUES (@MakeName, @DateAdded)

	SET @MakeId = SCOPE_IDENTITY();
END

GO

--Model Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllModels')
      DROP PROCEDURE SelectAllModels
GO

CREATE PROCEDURE SelectAllModels
AS
BEGIN
	SELECT ModelId, ModelName, DateAdded, MakeId
	FROM Model
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectModelById')
      DROP PROCEDURE SelectModelById
GO

CREATE PROCEDURE SelectModelById(

@ModelId INT

)AS
BEGIN
	SELECT ModelId, ModelName, DateAdded, MakeId
	FROM Model
	WHERE ModelId = @ModelId 
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
      DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@ModelId INT OUTPUT,
	@ModelName VARCHAR(30),
	@DateAdded DATETIME2,
	@MakeId INT
	
) AS
BEGIN
	INSERT INTO Model(ModelName, DateAdded, MakeId)
	VALUES (@ModelName, @DateAdded, @MakeId)

	SET @ModelId = SCOPE_IDENTITY();
END

GO

--Transmission Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectTransmissionById')
      DROP PROCEDURE SelectTransmissionById
GO

CREATE PROCEDURE SelectTransmissionById(

@TransmissionId INT

)AS
BEGIN
	SELECT @TransmissionId, TransmissionType
	FROM Transmission
	WHERE TransmissionId = @TransmissionId 
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllTransmissions')
      DROP PROCEDURE SelectAllTransmissions
GO

CREATE PROCEDURE SelectAllTransmissions
AS
BEGIN
	SELECT TransmissionId, TransmissionType
	FROM Transmission
END

GO

--Customer Contact Procedures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectCustomerContactById')
      DROP PROCEDURE SelectCustomerContactById
GO

CREATE PROCEDURE SelectCustomerContactById (
	@ContactId INT
) AS
BEGIN
	SELECT ContactId, Email, Phone, MessageBody, ContactName
	FROM CustomerContact
	WHERE ContactId = @ContactId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllCustomerContacts')
      DROP PROCEDURE SelectAllCustomerContacts
GO

CREATE PROCEDURE SelectAllCustomerContacts
AS
BEGIN
	SELECT ContactId, Email, Phone, MessageBody, ContactName
	FROM CustomerContact
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CustomerContactInsert')
      DROP PROCEDURE CustomerContactInsert
GO

CREATE PROCEDURE CustomerContactInsert (
	@ContactId INT OUTPUT,
	@ContactName VARCHAR(40),
	@Phone NVARCHAR(15),
	@Email NVARCHAR(50),
	@MessageBody NVARCHAR(400)
	
) AS
BEGIN
	INSERT INTO CustomerContact(ContactName, Phone, Email, MessageBody)
	VALUES (@ContactName, @Phone, @Email, @MessageBody)

	SET @ContactId = SCOPE_IDENTITY();
END

GO