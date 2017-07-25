using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IPurchaseLogRepository
    {
        IEnumerable<PurchaseLog> GetPurchaseLogs();
        PurchaseLog GetPurchaseLogById(int PurchaseLogId);
        void Insert(PurchaseLog PurchaseLog);
        void Update(PurchaseLog PurchaseLog);
    }
}
