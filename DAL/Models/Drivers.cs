using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Drivers
    {
        public Drivers()
        {
            DriverConstraints = new HashSet<DriverConstraints>();
        }

        public string DriverPhone { get; set; }
        public int? MaxPackageSize { get; set; }
        public int? MaxPackageNum { get; set; }
        public int? MaxDeviation { get; set; }

        public virtual Users DriverPhoneNavigation { get; set; }
        public virtual Sizes MaxPackageSizeNavigation { get; set; }
        public virtual ICollection<DriverConstraints> DriverConstraints { get; set; }
    }
}
