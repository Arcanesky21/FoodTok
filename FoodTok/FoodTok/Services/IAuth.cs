using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTok.Services
{
    public interface IAuth
    {
        Task<bool> LoginUserWithEmailAndPassword(string email, string password);
        Task<bool> SignUpWithEmailAndPassword(string email, string password, string username);

        bool SignOut();
        bool IsSignIn();

    }
}
