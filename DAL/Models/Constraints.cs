using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Constraints
    {
        public Constraints()
        {
            DriverConstraints = new HashSet<DriverConstraints>();
            PackageConstraints = new HashSet<PackageConstraints>();
        }

        public int ConstraintId { get; set; }
        public string ConstraintName { get; set; }

        public virtual ICollection<DriverConstraints> DriverConstraints { get; set; }
        public virtual ICollection<PackageConstraints> PackageConstraints { get; set; }
    }
}
