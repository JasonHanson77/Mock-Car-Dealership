using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IMakeRepository
    {
        IEnumerable<Make> GetAll();
        Make GetMakeById(int MakeId);
        void Insert(Make make);
    }
}
