using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UserDL : IUserDL
    {
        DeliverPackagesDBContext db;

        public UserDL(DeliverPackagesDBContext _db)
        {
            this.db = _db;
        }
        public async Task AddUserAsync(Users user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await this.db.Users.ToListAsync();
        }
    }
}
