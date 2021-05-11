using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class DriverConstraints
    {
        public string DriverPhone { get; set; }
        public int ConstraintId { get; set; }

        public virtual Constraints Constraint { get; set; }
        public virtual Drivers DriverPhoneNavigation { get; set; }
    }
}
