using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL
{
    public class DriverBL
    {
        IDriverDL driverDL;
        public DriverBL(IDriverDL _driverDL)
        {
            driverDL = _driverDL;
        }

        public async Task AddDriverAsync(Drivers driver)
        {
            await driverDL.AddDriverAsync(driver);
        }
    }
}
