using FoodTok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedView : ContentPage
    {

        FeedViewModel GetFeedViewModel;


        public FeedView()
        {
            InitializeComponent();
            BindingContext = GetFeedViewModel = new FeedViewModel();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetFeedViewModel.OnAppearing();
        }

        private void CommentWindow(object sender, EventArgs e)
        {
            _ = Navigation.PushModalAsync(new CommentView());
        }

        

        private async void ShareSomething(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://www.freepik.com/free-photo/mexican-quesadilla-sliced-with-vegetables-sauces-table_6804086.htm#query=food&position=6&from_view=keyword"
            }); 
        }
    }
}