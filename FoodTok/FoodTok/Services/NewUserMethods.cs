using FoodTok.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTok.Services
{
    public class NewUserMethods : IAddUserdb
    {
        public SQLiteAsyncConnection _database;

        public NewUserMethods(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NewUserModel>().Wait();
        }

        public Task<bool> GetUserInfo(NewUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NewUserAdded(NewUserModel userModel)
        {
            if(userModel.UserId > 0)
            {
                _ = await _database.UpdateAsync(userModel);
            }
            else
            {
                _ = await _database.InsertAsync(userModel);
            }
            return await Task.FromResult(true);

        }

        public Task<bool> UpdateUser(NewUserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
