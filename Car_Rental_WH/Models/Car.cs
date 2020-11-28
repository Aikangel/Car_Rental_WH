using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class Car
    {
        public Car()
        {
            CarBrands = new HashSet<CarBrand>();
        }

        public long VehicleCode { get; set; }
        public long BodyNumber { get; set; }
        public long EngineNumber { get; set; }
        public long RegistrationNumber { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public long Run { get; set; }
        public double CarPrice { get; set; }
        public double PriceOfTheRentalDay { get; set; }
        public DateTime LastToDate { get; set; }
        public string SpecialMark { get; set; }
        public string RefundMark { get; set; }
        public long TheCodeOfTheEmployee { get; set; }

        public virtual staff TheCodeOfTheEmployeeNavigation { get; set; }
        public virtual ICollection<CarBrand> CarBrands { get; set; }
    }
}
