using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FoodTok.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTok.Services
{
    public class UserServices
    {
        IAuth auth;

        public UserServices()
        {
            auth = DependencyService.Get<IAuth>();
        }

        public async Task<bool> RegisterUseer(string uname, string email, string passwd, string confirmPass)
        {

            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwd)
                || string.IsNullOrEmpty(confirmPass))
            {
                _ = Application.Current.MainPage.DisplayAlert("Error", "Field is empty", "OK");
                return false;
            }
            else
            {
                if(passwd != confirmPass)
                {
                    _ = Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                    return false;
                }
                else
                {
                    _ = await auth.SignUpWithEmailAndPassword(email, passwd, uname).ConfigureAwait(false);



                    return true;
                }
            }

        }


    }
}
