using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.Dtos
{
    public class CustomerDto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDto()
        {
            this.Rentals = new HashSet<Rental>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string DriverLicNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}