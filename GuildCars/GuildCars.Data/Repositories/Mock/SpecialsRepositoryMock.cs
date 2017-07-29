using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.Mock
{
    public class SpecialsRepositoryMock : ISpecialsRepository
    {
        private static List<Special> _specials = new List<Special>();

        private static Special _specialOne = new Special
        {
            SpecialId = 1,
            SpecialDetails = "$1000 Rebate on all Toyota SUVs!"
        };

        private static Special _specialTwo = new Special
        {
            SpecialId = 2,
            SpecialDetails = "Free tank of gas with every purchase!"
        };

        
        private static Special _specialThree = new Special
        {
            SpecialId = 3,
            SpecialDetails = "Free extended Warranty on all Ford models!"
        };

        private static Special _specialFour = new Special
        {
            SpecialId = 4,
            SpecialDetails = "1% Financing special all Summer Long!"
        };

        public SpecialsRepositoryMock()
        {
            if(_specials.Count != 0)
            {
                _specials.Clear();
            }

            _specials.Add(_specialOne);
            _specials.Add(_specialTwo);
            _specials.Add(_specialThree);
            _specials.Add(_specialFour);
        }

        public void Delete(int SpecialId)
        {
            Special special = _specials.FirstOrDefault(s => s.SpecialId == SpecialId);

            _specials.Remove(special);
        }

        public IEnumerable<Special> GetAll()
        {
            return _specials;
        }

        public void Insert(Special special)
        {
            special.SpecialId = _specials.Max(s => s.SpecialId) + 1;

            _specials.Add(special);
        }

        public void SpecialsClearList()
        {
            _specials.Clear();
        }
    }
}
