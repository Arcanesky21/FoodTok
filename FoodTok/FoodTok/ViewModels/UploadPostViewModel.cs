using FoodTok.Models;
using FoodTok.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTok.ViewModels
{
    public class UploadPostViewModel : BasePostViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public UploadPostViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            PostsModel = new PostsModel();
        }

        private async void OnSave()
        {
            var post = PostsModel;
            _ = await App.FoodTokService.AddPost(post);

          
        }

        private async void OnCancel() => await Application.Current.MainPage.Navigation.PushAsync(new UploadView());
    }
}
