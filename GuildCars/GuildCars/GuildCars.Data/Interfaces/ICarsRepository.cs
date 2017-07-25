using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ICarsRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int CarId);
        void Update(Car Car);
        void Delete(int CarId);
        void Insert(Car car);
        IEnumerable<Car> GetAllNewCars();
        IEnumerable<Car> GetAllUsedCars();
        IEnumerable<FeaturedShortListItem> GetAllFeaturedCars();
        IEnumerable<Car> GetAllSoldCars();
        IEnumerable<Car> GetAllUnsoldCars();
    }
}
