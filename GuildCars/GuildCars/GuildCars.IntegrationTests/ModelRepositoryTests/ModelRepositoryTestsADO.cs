using GuildCars.Data.Repositories.ADO;
using GuildCars.Data.Repositories.Mock;
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

namespace GuildCars.IntegrationTests.ModelRepositoryTests
{
    [TestFixture]
    public class ModelRepositoryTestsADO
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
        public void CanGetAllModels()
        {
            ModelRepositoryADO repo = new ModelRepositoryADO();

            List<Model> Models = repo.GetAll().ToList();

            Assert.AreEqual(4, Models.Count);

            Assert.AreEqual(Models[2].ModelId, 3);
            Assert.AreEqual(Models[2].ModelName, "TLX");
            Assert.AreEqual(Models[2].DateAdded, new DateTime(2017, 7, 2));
        }

        [Test]
        public void CanGetModelById()
        {
            ModelRepositoryADO repo = new ModelRepositoryADO();

            Model Model = repo.GetAll().FirstOrDefault(c => c.ModelId == 3);

            Assert.AreEqual(Model.ModelId, 3);
            Assert.AreEqual(Model.ModelName, "TLX");
            Assert.AreEqual(Model.DateAdded, new DateTime(2017, 7, 2));
        }

        [Test]
        public void CanAddModel()
        {
            Model model = new Model
            {
                MakeId = 2,
                ModelName = "TestModel",
                DateAdded = DateTime.Now.Date,

            };

            ModelRepositoryADO repo = new ModelRepositoryADO();
            repo.Insert(model);

            List<Model> Models = repo.GetAll().ToList();
            Assert.AreEqual(5, Models.Count);

            Assert.AreEqual(5, Models[4].ModelId);
            Assert.AreEqual(2, Models[4].MakeId);
            Assert.AreEqual(model.ModelName, Models[4].ModelName);
            Assert.AreEqual(model.DateAdded, Models[4].DateAdded);

        }
    }
}
