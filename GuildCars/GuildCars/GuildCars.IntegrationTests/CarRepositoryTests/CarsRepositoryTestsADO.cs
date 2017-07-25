using GuildCars.Data.Repositories.ADO;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.IntegrationTests
{
    [TestFixture]
    public class CarsRepositoryTestsADO
    {
        [SetUp]
        public void Init()
        {
            var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            try
            {
                using (dbConnection)
                {
                    var cmd = new SqlCommand();
                    cmd.CommandText = "GuildCarsDBReset";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Connection = dbConnection;
                    dbConnection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = String.Format(CultureInfo.CurrentCulture,
                          "Exception Type: {0}, Message: {1}{2}",
                          ex.GetType(),
                          ex.Message,
                          ex.InnerException == null ? String.Empty :
                          String.Format(CultureInfo.CurrentCulture,
                                       " InnerException Type: {0}, Message: {1}",
                                       ex.InnerException.GetType(),
                                       ex.InnerException.Message));

                System.Diagnostics.Debug.WriteLine(errorMessage);

                dbConnection.Close();
            }
        }

        [Test]
        public void CanGetCarById()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            Car car = repo.GetCarById(2);

            Assert.IsNotNull(car);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", car.VIN);
            Assert.AreEqual(2, car.CarId);
            Assert.AreEqual(2018, car.ModelYear);
            Assert.IsTrue(car.IsNew);
            Assert.IsFalse(car.IsSold);
            Assert.IsTrue(car.IsFeatured);
            Assert.AreEqual(5, car.UnitsInStock);
            Assert.AreEqual("200", car.Mileage);
            Assert.AreEqual(2, car.BodyColorId);
            Assert.AreEqual(2, car.BodyStyleId);
            Assert.AreEqual(2, car.TransmissionId);
            Assert.AreEqual(2, car.MakeId);
            Assert.AreEqual(3, car.ModelId);
            Assert.AreEqual(3, car.InteriorColorId);
            Assert.AreEqual(33000.00m, car.SalePrice);
            Assert.AreEqual(34150.00m, car.MSRP);
            Assert.AreEqual(@"Images\2018AcuraTLX.png", car.IMGFilePath);
            Assert.AreEqual("A silver bullet of power and dependability.", car.VehicleDetails);
        }

        [Test]
        public void CanGetAllCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllCars().ToList();

            Assert.AreEqual(4, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(2018, cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(5, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(2, cars[1].BodyStyleId);
            Assert.AreEqual(2, cars[1].TransmissionId);
            Assert.AreEqual(2, cars[1].MakeId);
            Assert.AreEqual(3, cars[1].ModelId);
            Assert.AreEqual(3, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual(@"Images\2018AcuraTLX.png", cars[1].IMGFilePath);
            Assert.AreEqual("A silver bullet of power and dependability.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetFeaturedCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<FeaturedShortListItem> featuredCars = repo.GetAllFeaturedCars().ToList();

            Assert.AreEqual(2, featuredCars.Count);

            Assert.AreEqual(2, featuredCars[0].CarId);
            Assert.AreEqual(2018, featuredCars[0].Year);
            Assert.AreEqual(2, featuredCars[0].MakeId);
            Assert.AreEqual(3, featuredCars[0].ModelId);
            Assert.AreEqual(33000.00m, featuredCars[0].Price);
            Assert.AreEqual(@"Images\2018AcuraTLX.png", featuredCars[0].ImageURL);
            Assert.AreEqual("Acura", featuredCars[0].Make);
            Assert.AreEqual("TLX", featuredCars[0].Model);
        }

        [Test]
        public void CanGetNewCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllNewCars().ToList();

            Assert.AreEqual(2, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(2018, cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(5, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(2, cars[1].BodyStyleId);
            Assert.AreEqual(2, cars[1].TransmissionId);
            Assert.AreEqual(2, cars[1].MakeId);
            Assert.AreEqual(3, cars[1].ModelId);
            Assert.AreEqual(3, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual(@"Images\2018AcuraTLX.png", cars[1].IMGFilePath);
            Assert.AreEqual("A silver bullet of power and dependability.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUsedCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllUsedCars().ToList();

            Assert.AreEqual(2, cars.Count);

            Assert.AreEqual("4ABC4ABC4ABC4ABC4", cars[1].VIN);
            Assert.AreEqual(4, cars[1].CarId);
            Assert.AreEqual(2005, cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsFalse(cars[1].IsFeatured);
            Assert.AreEqual(1, cars[1].UnitsInStock);
            Assert.AreEqual("111200", cars[1].Mileage);
            Assert.AreEqual(5, cars[1].BodyColorId);
            Assert.AreEqual(4, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(4, cars[1].MakeId);
            Assert.AreEqual(4, cars[1].ModelId);
            Assert.AreEqual(4, cars[1].InteriorColorId);
            Assert.AreEqual(4000.00m, cars[1].SalePrice);
            Assert.AreEqual(5000.00m, cars[1].MSRP);
            Assert.AreEqual(@"Images\2005DodgeGrandCaravan.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Certified and ready to take your family anywhere.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUnsoldCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllUnsoldCars().ToList();

            Assert.AreEqual(2, cars.Count);

            Assert.AreEqual("4ABC4ABC4ABC4ABC4", cars[1].VIN);
            Assert.AreEqual(4, cars[1].CarId);
            Assert.AreEqual(2005, cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsFalse(cars[1].IsFeatured);
            Assert.AreEqual(1, cars[1].UnitsInStock);
            Assert.AreEqual("111200", cars[1].Mileage);
            Assert.AreEqual(5, cars[1].BodyColorId);
            Assert.AreEqual(4, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(4, cars[1].MakeId);
            Assert.AreEqual(4, cars[1].ModelId);
            Assert.AreEqual(4, cars[1].InteriorColorId);
            Assert.AreEqual(4000.00m, cars[1].SalePrice);
            Assert.AreEqual(5000.00m, cars[1].MSRP);
            Assert.AreEqual(@"Images\2005DodgeGrandCaravan.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Certified and ready to take your family anywhere.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetSoldCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllSoldCars().ToList();

            Assert.AreEqual(2, cars.Count);

            Assert.AreEqual("3ABC3ABC3ABC3ABC3", cars[1].VIN);
            Assert.AreEqual(3, cars[1].CarId);
            Assert.AreEqual(2017, cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsTrue(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(1, cars[1].UnitsInStock);
            Assert.AreEqual("1200", cars[1].Mileage);
            Assert.AreEqual(5, cars[1].BodyColorId);
            Assert.AreEqual(3, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(3, cars[1].MakeId);
            Assert.AreEqual(1, cars[1].ModelId);
            Assert.AreEqual(5, cars[1].InteriorColorId);
            Assert.AreEqual(22669.00m, cars[1].SalePrice);
            Assert.AreEqual(24500.00m, cars[1].MSRP);
            Assert.AreEqual(@"Images\2017FordEscape.png", cars[1].IMGFilePath);
            Assert.AreEqual("Loaded! Used Price for Brand New Quality.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanAddCar()
        {
            Car car = new Car
            {
                ModelYear = 2015,
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();
            repo.Insert(car);

            List<Car> cars = repo.GetAllCars().ToList();
            Assert.AreEqual(5, cars.Count);

            Assert.AreEqual(5, cars[4].CarId);
            Assert.AreEqual(car.ModelYear, cars[4].ModelYear);
            Assert.AreEqual(car.IsNew, cars[4].IsNew);
            Assert.AreEqual(car.IsFeatured, cars[4].IsFeatured);
            Assert.AreEqual(car.IsSold, cars[4].IsSold);
            Assert.AreEqual(car.UnitsInStock, cars[4].UnitsInStock);
            Assert.AreEqual(car.Mileage, cars[4].Mileage);
            Assert.AreEqual(car.VIN, cars[4].VIN);
            Assert.AreEqual(car.BodyColorId, cars[4].BodyColorId);
            Assert.AreEqual(car.BodyStyleId, cars[4].BodyStyleId);
            Assert.AreEqual(car.TransmissionId, cars[4].TransmissionId);
            Assert.AreEqual(car.MakeId, cars[4].MakeId);
            Assert.AreEqual(car.ModelId, cars[4].ModelId);
            Assert.AreEqual(car.InteriorColorId, cars[4].InteriorColorId);
            Assert.AreEqual(car.SalePrice, cars[4].SalePrice);
            Assert.AreEqual(car.MSRP, cars[4].MSRP);
            Assert.AreEqual(car.IMGFilePath, cars[4].IMGFilePath);
            Assert.AreEqual(car.VehicleDetails, cars[4].VehicleDetails);

        }

        [Test]
        public void CanDeleteCar()
        {
            Car car = new Car
            {
                ModelYear = 2015,
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();

            repo.Insert(car);

            var newCar = repo.GetCarById(5);

            Assert.IsNotNull(newCar);

            repo.Delete(5);

            newCar = repo.GetCarById(5);

            Assert.IsNull(newCar);

        }

        [Test]
        public void CanUpdateCar()
        {
            Car car = new Car
            {
                ModelYear = 2015,
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();

            repo.Insert(car);

            car.BodyColorId = 2;
            car.InteriorColorId = 5;
            car.SalePrice = 17500m;
            car.MSRP = 19200m;
            car.IMGFilePath = "Images/updatedImage.png";
            car.IsSold = true;
            car.IsNew = true;
            car.IsFeatured = true;
            car.VIN = "6ABC6ABC6ABC6ABC6";
            car.VehicleDetails = "Updated";
            car.Mileage = "3";
            car.ModelYear = 2018;
            car.MakeId = 2;
            car.ModelId = 3;
            car.TransmissionId = 1;
            car.UnitsInStock = 9;
            car.BodyStyleId = 2;

            repo.Update(car);

            var updatedCar = repo.GetCarById(5);

            Assert.AreEqual(updatedCar.BodyStyleId, 2);
            Assert.AreEqual(updatedCar.BodyColorId, 2);
            Assert.AreEqual(updatedCar.InteriorColorId, 5);
            Assert.AreEqual(updatedCar.IMGFilePath, "Images/updatedImage.png");
            Assert.AreEqual(updatedCar.SalePrice, 17500m);
            Assert.AreEqual(updatedCar.MSRP, 19200m);
            Assert.AreEqual(updatedCar.IsNew, true);
            Assert.AreEqual(updatedCar.IsFeatured, true);
            Assert.AreEqual(updatedCar.IsSold, true);
            Assert.AreEqual(updatedCar.VIN, "6ABC6ABC6ABC6ABC6");
            Assert.AreEqual(updatedCar.VehicleDetails, "Updated");
            Assert.AreEqual(updatedCar.Mileage, "3");
            Assert.AreEqual(updatedCar.ModelYear, 2018);
            Assert.AreEqual(updatedCar.MakeId, 2);
            Assert.AreEqual(updatedCar.ModelId, 3);
            Assert.AreEqual(updatedCar.TransmissionId, 1);
            Assert.AreEqual(updatedCar.UnitsInStock, 9);
        }
    }
}
