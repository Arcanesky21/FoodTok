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
    public partial class UploadView : ContentPage
    {

        public PostsModel PostsModel { get; set; }
        public UploadView()
        {
            InitializeComponent();
            BindingContext = new UploadPostViewModel();
        }
    }
}