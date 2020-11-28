using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class Customer
    {
        public long ClientCode { get; set; }
        public string FullName { get; set; }
        public string Paul { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string PassportData { get; set; }
    }
}
