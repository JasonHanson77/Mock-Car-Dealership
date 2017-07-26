using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedShortListItem
    {
        public int CarId { get; set; }
        public string ImageURL { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
