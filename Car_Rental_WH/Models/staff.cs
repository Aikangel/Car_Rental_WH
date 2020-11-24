using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class staff
    {
        public staff()
        {
            Cars = new HashSet<Car>();
        }

        public long StaffCode { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public string Paul { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string PassportData { get; set; }
        public long PositionCode { get; set; }

        public virtual Position PositionCodeNavigation { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
