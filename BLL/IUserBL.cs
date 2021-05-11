using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IUserBL
    {
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);
    }
}
