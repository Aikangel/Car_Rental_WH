using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class ComplementaryService
    {
        public long ServiceCode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
