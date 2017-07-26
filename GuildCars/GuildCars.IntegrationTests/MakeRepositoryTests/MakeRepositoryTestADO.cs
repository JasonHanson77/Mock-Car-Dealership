﻿using GuildCars.Data.Repositories.ADO;
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

namespace GuildCars.IntegrationTests.MakeRepositoryTests
{
    [TestFixture]
    public class MakeRepositoryTestADO
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
        public void CanGetAllMakes()
        {
            MakeRepositoryADO repo = new MakeRepositoryADO();

            List<Make> Makes = repo.GetAll().ToList();

            Assert.AreEqual(4, Makes.Count);

            Assert.AreEqual(Makes[2].MakeId, 3);
            Assert.AreEqual(Makes[2].MakeName, "Ford");
            Assert.AreEqual(Makes[2].DateAdded, new DateTime(2015, 6, 2));
        }

        [Test]
        public void CanGetMakeById()
        {
            MakeRepositoryADO repo = new MakeRepositoryADO();

            Make Make = repo.GetAll().FirstOrDefault(c => c.MakeId == 3);

            Assert.AreEqual(Make.MakeId, 3);
            Assert.AreEqual(Make.MakeName, "Ford");
            Assert.AreEqual(Make.DateAdded, new DateTime(2015, 6, 2));
        }

        [Test]
        public void CanAddMake()
        {
            Make make = new Make
            {
                MakeName = "TestMake",
                DateAdded = DateTime.Now.Date,
              
            };

            MakeRepositoryADO repo = new MakeRepositoryADO();
            repo.Insert(make);

            List<Make> makes = repo.GetAll().ToList();
            Assert.AreEqual(5, makes.Count);

            Assert.AreEqual(5, makes[4].MakeId);
            Assert.AreEqual(make.MakeName, makes[4].MakeName);
            Assert.AreEqual(make.DateAdded, makes[4].DateAdded);
           
        }
    }
}
