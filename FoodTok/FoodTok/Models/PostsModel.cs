using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTok.Models
{
    public class PostsModel
    {
        [PrimaryKey, AutoIncrement]
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string Username { get; set; }
        public string Recipe { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
    }
}
