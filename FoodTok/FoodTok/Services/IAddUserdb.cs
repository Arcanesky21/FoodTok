using FoodTok.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTok.Services
{
    public interface IAddUserdb
    {
        Task<bool> NewUserAdded(NewUserModel userModel);
        Task<bool> UpdateUser(NewUserModel userModel);
        Task<bool> GetUserInfo(NewUserModel userModel);
    }
}
