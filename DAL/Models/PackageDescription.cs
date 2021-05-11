using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PackageDescription
    {
        public int PackDescId { get; set; }
        public int SizeId { get; set; }
        public bool? IsFragile { get; set; }
        public bool? IisFood { get; set; }
        public bool? IsExpensive { get; set; }

        public virtual Sizes Size { get; set; }
    }
}
