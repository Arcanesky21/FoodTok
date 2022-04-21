using FoodTok.Services;
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
    public partial class LoginView : ContentPage
    {
        IAuth auth;
        public LoginView()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        private async void GotoSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpView());
        }

        private async void SignInUser(object sender, EventArgs e)
        {
            try
            {
                bool result = await auth.LoginUserWithEmailAndPassword(emailfield.Text, passfield.Text);
                if (result == true)
                {
                    await Navigation.PushAsync(new HomePageView());
                }
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Field is Empty", "OK");
            }
        }
    }
}