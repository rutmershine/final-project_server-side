using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PackageConstraints
    {
        public int PackageId { get; set; }
        public int ConstraintId { get; set; }

        public virtual Constraints Constraint { get; set; }
        public virtual Package Package { get; set; }
    }
}
