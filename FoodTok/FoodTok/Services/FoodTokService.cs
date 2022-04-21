using FoodTok.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTok.Services
{
    public class FoodTokService : IDatabaseRepo
    {

        public SQLiteAsyncConnection _database;

        public FoodTokService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PostsModel>().Wait();
        }

        public async Task<bool> AddPost(PostsModel posts)
        {
            if(posts.PostId > 0)
            {
                _ = await _database.UpdateAsync(posts);
            }
            else
            {
                _ = await _database.InsertAsync(posts);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePost(int id)
        {
            _ = await _database.DeleteAsync<PostsModel>(id);
            return await Task.FromResult(true);
        }

        public async Task<PostsModel> GetPosts(int id)
        {

            return await _database.Table<PostsModel>().Where(p => p.PostId == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<PostsModel>> GetAllPosts()
        {
            return await Task.FromResult(await _database.Table<PostsModel>().ToListAsync());


        }


        public Task<bool> UpdatePost(PostsModel posts)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostsModel>> GetAllUserPosts(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostsModel>> SearchPost(string searchEntry)
        {
            return await Task.FromResult(await _database.Table<PostsModel>().Where(p => p.Username.Contains(searchEntry) || p.PostTitle.Contains(searchEntry)).ToListAsync());

        }
    }
}
