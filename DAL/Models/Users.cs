using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Users
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }

        public virtual Drivers Drivers { get; set; }
    }
}
