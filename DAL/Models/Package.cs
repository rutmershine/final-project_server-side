using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Package
    {
        public Package()
        {
            PackageConstraints = new HashSet<PackageConstraints>();
        }

        public int PackageId { get; set; }
        public string SenderPhone { get; set; }
        public string GetterPhone { get; set; }
        public int? DriveId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int SourceAddressId { get; set; }
        public int DestAddressId { get; set; }

        public virtual Address DestAddress { get; set; }
        public virtual Travels Drive { get; set; }
        public virtual Address SourceAddress { get; set; }
        public virtual ICollection<PackageConstraints> PackageConstraints { get; set; }
    }
}
