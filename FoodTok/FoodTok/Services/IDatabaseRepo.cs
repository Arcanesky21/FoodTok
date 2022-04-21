using FoodTok.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTok.Services
{
    public interface IDatabaseRepo
    {
        Task<bool> AddPost(PostsModel posts);
        Task<bool> UpdatePost(PostsModel posts);
        Task<bool> DeletePost(int id);
        Task<PostsModel> GetPosts(int id);
        Task<IEnumerable<PostsModel>> GetAllUserPosts(string username);
        Task<IEnumerable<PostsModel>> SearchPost(string username);
        Task<IEnumerable<PostsModel>> GetAllPosts();
    }
}
