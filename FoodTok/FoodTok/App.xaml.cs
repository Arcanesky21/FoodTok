using FoodTok.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTok
{
    public partial class App : Application
    {

        static FoodTokService _foodTokService;
        public static FoodTokService FoodTokService
        {
            get
            {
                if(_foodTokService == null)
                {
                    _foodTokService = new FoodTokService(Path.Combine(Environment
                        .GetFolderPath(Environment
                        .SpecialFolder.LocalApplicationData), "Posts.db3"));
                }
                return _foodTokService;
            }
        }

        static NewUserMethods newUserMethods;
        public static NewUserMethods GetNewUserMethods
        {
            get
            {
                if (newUserMethods == null)
                {
                    newUserMethods = new NewUserMethods(Path.Combine(Environment
                        .GetFolderPath(Environment
                        .SpecialFolder.LocalApplicationData), "Posts.db3"));
                }
                return newUserMethods;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
