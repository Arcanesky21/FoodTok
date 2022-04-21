using FoodTok.Models;
using FoodTok.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTok.ViewModels
{
    public class FeedViewModel : BasePostViewModel
    {

        public Command LoadFeedCommand { get; }
        public ObservableCollection<PostsModel> postsModels { get; }
        public Command GotoProfile { get; }

        public FeedViewModel()
        {
            LoadFeedCommand = new Command(async () => await ExecuteLoadFeedCommand());
            postsModels = new ObservableCollection<PostsModel>();
        }

      
        private async Task ExecuteLoadFeedCommand()
        {
            IsBusy = true;
            try
            {
                postsModels.Clear();
                var feedPosts = await App.FoodTokService.GetAllPosts();
                foreach (var post in feedPosts)
                {
                    postsModels.Add(post);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public void OnAppearing()
        {
            IsBusy = true;

        }
    }
}
