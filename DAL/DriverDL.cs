using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DriverDL :IDriverDL
    {
        DeliverPackagesDBContext db;

        public DriverDL(DeliverPackagesDBContext _db)
        {
            this.db = _db;
        }

        public async Task AddDriverAsync(Drivers driver)
        {
            await db.Drivers.AddAsync(driver);
            await db.SaveChangesAsync();
        }
    }
}
