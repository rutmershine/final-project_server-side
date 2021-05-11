using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;
        public UserBL(IUserDL _userDL)
        {
            userDL = _userDL;
        }
        public async Task AddUserAsync(Users user)
        {
            await userDL.AddUserAsync(user);
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await userDL.GetAllUsersAsync();
        }
    }
}
