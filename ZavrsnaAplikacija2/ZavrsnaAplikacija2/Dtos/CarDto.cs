using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.Dtos
{
    public class CarDto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarDto()
        {
            this.Rentals = new HashSet<Rental>();
        }

        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<bool> Available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}