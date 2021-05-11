using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public interface IUserDL
    {
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);


    }
}
