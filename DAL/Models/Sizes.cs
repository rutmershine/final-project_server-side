using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Sizes
    {
        public Sizes()
        {
            Drivers = new HashSet<Drivers>();
            PackageDescription = new HashSet<PackageDescription>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Drivers> Drivers { get; set; }
        public virtual ICollection<PackageDescription> PackageDescription { get; set; }
    }
}
