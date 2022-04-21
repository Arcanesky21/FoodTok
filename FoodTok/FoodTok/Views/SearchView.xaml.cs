using FoodTok.Models;
using FoodTok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        public SearchView()
        {
            InitializeComponent();
            BindingContext = new SearchViewModel();
        }

        private async void SearchResults_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var post = ((ListView)sender).SelectedItem as PostsModel;
            if (post == null)
            {
                return;
            }

            await DisplayAlert(post.PostTitle + " Recipe", post.Recipe, "OK");
        }

        private void SearchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var post = ((MenuItem)sender).BindingContext as PostsModel;

            if (post == null)
            {
                return;
            }

            await DisplayAlert("Food Favourited", post.PostTitle, "OK");

        }
    }
}