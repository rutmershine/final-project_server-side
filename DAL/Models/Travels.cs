using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Travels
    {
        public Travels()
        {
            Package = new HashSet<Package>();
        }

        public int TravelId { get; set; }
        public int DriverId { get; set; }
        public int SourceAddressId { get; set; }
        public int DestAddressId { get; set; }
        public DateTime LeavingDate { get; set; }

        public virtual Address DestAddress { get; set; }
        public virtual Address SourceAddress { get; set; }
        public virtual ICollection<Package> Package { get; set; }
    }
}
