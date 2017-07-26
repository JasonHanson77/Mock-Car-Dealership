using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SearchResultItem
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string IMGURL { get; set; }
        public string InteriorColor { get; set; }
        public string BodyColor { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal  MRSP { get; set; }
    }
}
