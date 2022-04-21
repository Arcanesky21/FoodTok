using FirebaseAdmin.Auth;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTok.Models
{
    public class NewUserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        
    }
}
