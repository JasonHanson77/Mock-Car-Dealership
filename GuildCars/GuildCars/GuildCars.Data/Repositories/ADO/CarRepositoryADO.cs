using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using GuildCars.Models.Queries;

namespace GuildCars.Data.Repositories.ADO
{
    public class CarsRepositoryADO : ICarsRepository
    {
        public void Delete(int CarId)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("CarDelete", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarId", CarId);

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();
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
        }

        public IEnumerable<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Car car = new Car();

                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();

                            cars.Add(car);
                        }
                    }
                    return cars;
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
                return cars;
            }
        }

        public IEnumerable<FeaturedShortListItem> GetAllFeaturedCars()
        {
            List<FeaturedShortListItem> featuredCars = new List<FeaturedShortListItem>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectFeaturedCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@isFeatured", "true");

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FeaturedShortListItem featuredCar = new FeaturedShortListItem();

                            featuredCar.CarId = (int)dr["CarId"];
                            featuredCar.ImageURL = dr["IMGFilePath"].ToString();
                            featuredCar.MakeId = (int)dr["MakeId"];
                            featuredCar.ModelId = (int)dr["ModelId"];
                            featuredCar.Make = dr["MakeName"].ToString();
                            featuredCar.Model = dr["ModelName"].ToString();
                            featuredCar.Year = (int)dr["ModelYear"];
                            featuredCar.Price = (decimal)dr["SalePrice"];

                            featuredCars.Add(featuredCar);
                        }
                    }
                    return featuredCars;
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
                return featuredCars;
            }
        }

            public IEnumerable<Car> GetAllNewCars()
        {
            List<Car> cars = new List<Car>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllNewCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Car car = new Car();

                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();

                            cars.Add(car);
                        }
                    }
                    return cars;
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
                return cars;
            }
        }

        public IEnumerable<Car> GetAllSoldCars()
        {
            List<Car> cars = new List<Car>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllSoldCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Car car = new Car();

                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();

                            cars.Add(car);
                        }
                    }
                    return cars;
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
                return cars;
            }
        }

        public IEnumerable<Car> GetAllUnsoldCars()
        {
            List<Car> cars = new List<Car>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllUnsoldCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Car car = new Car();

                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();

                            cars.Add(car);
                        }
                    }
                    return cars;
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
                return cars;
            }
        }

        public IEnumerable<Car> GetAllUsedCars()
        {
            List<Car> cars = new List<Car>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllUsedCars", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Car car = new Car();

                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();

                            cars.Add(car);
                        }
                    }
                    return cars;
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
                return cars;
            }
        }

        public Car GetCarById(int CarId)
        {
            Car car = null;

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    dbConnection.Open();

                    SqlCommand cmd = new SqlCommand("SelectCarById", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarId", CarId);



                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            car = new Car();
                            car.CarId = (int)dr["CarId"];
                            car.ModelYear = (int)dr["ModelYear"];
                            car.IsNew = (bool)dr["IsNew"];
                            car.IsFeatured = (bool)dr["IsFeatured"];
                            car.IsSold = (bool)dr["IsSold"];
                            car.BodyColorId = (int)dr["BodyColorId"];
                            car.BodyStyleId = (int)dr["BodyStyleId"];
                            car.InteriorColorId = (int)dr["InteriorColorId"];
                            car.ModelId = (int)dr["ModelId"];
                            car.MakeId = (int)dr["MakeId"];
                            car.MSRP = (decimal)dr["MSRP"];
                            car.SalePrice = (decimal)dr["SalePrice"];
                            car.Mileage = dr["Mileage"].ToString();
                            car.TransmissionId = (int)dr["TransmissionId"];
                            car.UnitsInStock = (int)dr["UnitsInStock"];
                            car.VehicleDetails = dr["VehicleDetails"].ToString();
                            car.VIN = dr["VIN"].ToString();
                            car.IMGFilePath = dr["IMGFILEPath"].ToString();
                        }
                    }


                    return car;
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

                return car;
            }
        }

        public void Insert(Car car)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("CarInsert", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(param);

                    cmd.Parameters.AddWithValue("@ModelYear", car.ModelYear);
                    cmd.Parameters.AddWithValue("@IsNew", car.IsNew);
                    cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);
                    cmd.Parameters.AddWithValue("@IsSold", car.IsSold);
                    cmd.Parameters.AddWithValue("@UnitsInStock", car.UnitsInStock);
                    cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                    cmd.Parameters.AddWithValue("@VIN", car.VIN);
                    cmd.Parameters.AddWithValue("@BodyColorId", car.BodyColorId);
                    cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                    cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                    cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                    cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                    cmd.Parameters.AddWithValue("@InteriorColorId", car.InteriorColorId);
                    cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                    cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                    cmd.Parameters.AddWithValue("@IMGFilePath", car.IMGFilePath);
                    cmd.Parameters.AddWithValue("@VehicleDetails", car.VehicleDetails);

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();

                    car.CarId = (int)param.Value;
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
        }

        public void Update(Car Car)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("CarUpdate", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarId", Car.CarId);
                    cmd.Parameters.AddWithValue("@ModelYear", Car.ModelYear);
                    cmd.Parameters.AddWithValue("@IsNew", Car.IsNew);
                    cmd.Parameters.AddWithValue("@IsFeatured", Car.IsFeatured);
                    cmd.Parameters.AddWithValue("@IsSold", Car.IsSold);
                    cmd.Parameters.AddWithValue("@Mileage", Car.Mileage);
                    cmd.Parameters.AddWithValue("@UnitsInStock", Car.UnitsInStock);
                    cmd.Parameters.AddWithValue("@BodyColorId", Car.BodyColorId);
                    cmd.Parameters.AddWithValue("@BodyStyleId", Car.BodyStyleId);
                    cmd.Parameters.AddWithValue("@InteriorColorId", Car.InteriorColorId);
                    cmd.Parameters.AddWithValue("@VIN", Car.VIN);
                    cmd.Parameters.AddWithValue("@SalePrice", Car.SalePrice);
                    cmd.Parameters.AddWithValue("@MSRP", Car.MSRP);
                    cmd.Parameters.AddWithValue("@IMGFilePath", Car.IMGFilePath);
                    cmd.Parameters.AddWithValue("@VehicleDetails", Car.VehicleDetails);
                    cmd.Parameters.AddWithValue("@ModelId", Car.ModelId);
                    cmd.Parameters.AddWithValue("@MakeId", Car.MakeId);
                    cmd.Parameters.AddWithValue("@TransmissionId", Car.TransmissionId);

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();
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
        }
    }
}
