using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Rental_WH.Models
{
    public partial class Position
    {
        public Position()
        {
            staff = new HashSet<staff>();
        }

        public long PositionCode { get; set; }
        public string TheNameOfThePosition { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
