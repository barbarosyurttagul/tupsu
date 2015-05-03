using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupveSuAboneTakip.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public DateTime RecordDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string GSM { get; set; }
        public int GroupID { get; set; }
        public int DistrictID { get; set; }
        public string Road { get; set; }
        public string Street { get; set; }
        public string SiteName { get; set; }
        public string ApartmentName { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public int FlatNumber { get; set; }
        public string AddressDetail { get; set; }
        public string FirmName { get; set; }
        public string CityName { get; set; }
        public string TownName { get; set; }

        public Group GroupOf { get; set; }
    }
}
