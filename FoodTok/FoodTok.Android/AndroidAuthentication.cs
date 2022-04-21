using Android.Gms.Extensions;
using Firebase.Auth;
using FirebaseAdmin.Auth;
using FoodTok.Droid;
using Google.Cloud.Firestore;
using FoodTok.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using FirebaseAuth = Firebase.Auth.FirebaseAuth;
using System.Diagnostics;


[assembly: Dependency(typeof(AndroidAuthentication))]
namespace FoodTok.Droid
{
    class AndroidAuthentication : IAuth
    {
        public bool IsSignIn()
        {
            FirebaseUser Uzer = FirebaseAuth.Instance.CurrentUser;
            return Uzer != null;
        }

        public async Task<bool> LoginUserWithEmailAndPassword(string email, string password)
        {
            try
            {
                IAuthResult NewUser = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;



            }
            catch (FirebaseAuthInvalidCredentialsException err)
            {
                err.PrintStackTrace();
                await Application.Current.MainPage.DisplayAlert("Failed", err.Message, "OK");
                return false;
            }
            catch (FirebaseAuthInvalidUserException err)
            {
                err.PrintStackTrace();
                await Application.Current.MainPage.DisplayAlert("Failed", err.Message, "OK");

                return false;
            }
        }

        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SignUpWithEmailAndPassword(string email, string password, string username)
        {
            try
            {
                IAuthResult NewUser = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return true;



            }
            catch (FirebaseAuthInvalidCredentialsException err)
            {
                err.PrintStackTrace();
                await Application.Current.MainPage.DisplayAlert("Error", err.Message, "OK");

                return false;
            }
            catch (FirebaseAuthInvalidUserException err)
            {
                err.PrintStackTrace();
                await Application.Current.MainPage.DisplayAlert("Error", err.Message, "OK");
                return false;
            }
        }
    }
}