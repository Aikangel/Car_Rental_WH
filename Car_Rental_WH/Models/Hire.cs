using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class Hire
    {
        public byte[] DateOfIssue { get; set; }
        public byte[] RentalPeriod { get; set; }
        public byte[] ReturnDate { get; set; }
        public long VehicleCode { get; set; }
        public long ClientCode { get; set; }
        public long ServiceCode { get; set; }

        public virtual Customer ClientCodeNavigation { get; set; }
        public virtual ComplementaryService ServiceCodeNavigation { get; set; }
        public virtual Car VehicleCodeNavigation { get; set; }
    }
}
