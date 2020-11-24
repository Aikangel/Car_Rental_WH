using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class CarBrand
    {
        public long BrandCode { get; set; }
        public string Name { get; set; }
        public string TechnicalParameters { get; set; }
        public string Description { get; set; }
        public long? VehicleCode { get; set; }

        public virtual Car VehicleCodeNavigation { get; set; }
    }
}
