using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.Dtos
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<System.DateTime> DateRented { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}