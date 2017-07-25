using GuildCars.Data.Repositories.Mock;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.IntegrationTests.MakeRepositoryTests
{
    [TestFixture]
    public class MakeRepositoryTestsMock
    {

        MakeRepositoryMock repo;

        [SetUp]
        public void Init()
        {
            repo = new MakeRepositoryMock();
        }

        [TearDown]
        public void ResetRepo()
        {
            repo.ClearMakesList();
        }

        [Test]
        public void CanGetAllMakes()
        {
            MakeRepositoryMock repo = new MakeRepositoryMock();

            List<Make> Makes = repo.GetAll().ToList();

            Assert.AreEqual(4, Makes.Count);

            Assert.AreEqual(Makes[2].MakeId, 3);
            Assert.AreEqual(Makes[2].MakeName, "Ford");
            Assert.AreEqual(Makes[2].DateAdded, new DateTime(2015, 6, 2));
        }

        [Test]
        public void CanGetMakeById()
        {
            MakeRepositoryMock repo = new MakeRepositoryMock();

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

            MakeRepositoryMock repo = new MakeRepositoryMock();
            repo.Insert(make);

            List<Make> makes = repo.GetAll().ToList();
            Assert.AreEqual(5, makes.Count);

            Assert.AreEqual(5, makes[4].MakeId);
            Assert.AreEqual(make.MakeName, makes[4].MakeName);
            Assert.AreEqual(make.DateAdded, makes[4].DateAdded);

        }
    }
}
