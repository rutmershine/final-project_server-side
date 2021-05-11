using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Address
    {
        public Address()
        {
            PackageDestAddress = new HashSet<Package>();
            PackageSourceAddress = new HashSet<Package>();
            TravelsDestAddress = new HashSet<Travels>();
            TravelsSourceAddress = new HashSet<Travels>();
        }

        public int AddressId { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public virtual ICollection<Package> PackageDestAddress { get; set; }
        public virtual ICollection<Package> PackageSourceAddress { get; set; }
        public virtual ICollection<Travels> TravelsDestAddress { get; set; }
        public virtual ICollection<Travels> TravelsSourceAddress { get; set; }
    }
}
