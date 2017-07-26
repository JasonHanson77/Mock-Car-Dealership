using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class PurchaseLog
    {
        public int PurchaseLogId { get; set; }
        public string PurchaseType { get; set; }
        public string PurchaseName { get; set; }
        public int CarId { get; set; }
        public string MessageBody { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public int SalesPersonId { get; set; }
        public DateTime DateSold { get; set; }
    }
}
