using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IReportsRepository
    {
        IEnumerable<SalesReportListingItem> GetSalesReport();
        IEnumerable<InventoryReportListingItem> GetInventory();
        IEnumerable<SalesReportListingItem> SearchSalesReports(SalesSearchParameters Parameters);
    }
}
