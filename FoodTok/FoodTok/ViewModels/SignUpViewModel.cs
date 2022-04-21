using FoodTok.Services;
using FoodTok.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace FoodTok.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        IAuth Auth;


        private string _Email;
        public string Email
        {
            get => _Email;
            set { _Email = value; OnPropertyChanged(); }
        }

        private string _Username;
        public string Username
        {
            get => _Username;
            set { _Username = value; OnPropertyChanged(); }
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set { _Password = value; OnPropertyChanged(); }
        }

        private string _ConfirmPass;
        public string ConfirmPass
        {
            get => _ConfirmPass;
            set { _ConfirmPass = value; OnPropertyChanged(); }
        }

        public bool IsBusy { get; set; }
        public bool Result { get; set; }


        public Command RegisterCommand { get; set; }

        public SignUpViewModel()
        {

            Auth = DependencyService.Get<IAuth>();

            RegisterCommand = new Command( () => RegisterCommandAsync());
        }

        private async void RegisterCommandAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPass))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Field is Empty", "OK");
            }
            else
            {
                if(Password == ConfirmPass)
                {
                    try
                    {
                        bool usr = await Auth.SignUpWithEmailAndPassword(Email, Password, Username);
                        if (usr)
                        {

                            await Application.Current.MainPage.DisplayAlert("Success", "New User Created", "OK");
                            try
                            {
                                _ = await App.GetNewUserMethods.NewUserAdded(new Models.NewUserModel
                                {
                                    Email = Email,
                                    Username = Username
                                });
                            }
                            catch (Exception err)
                            {
                                await Application.Current.MainPage.DisplayAlert("Failed", err.Message, "ok");
                            }
                            bool signOut = Auth.SignOut();

                            if (signOut)
                            {
                                await Application.Current.MainPage.Navigation.PushAsync(new LoginView());
                            }

                        }



                    }
                    catch (Exception err)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", err.Message, "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password does not match", "OK");
                }
            }


            

            
        }
    }
}
