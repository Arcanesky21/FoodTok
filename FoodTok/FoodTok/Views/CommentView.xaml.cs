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
    public partial class CommentView : ContentPage
    {
        public CommentView()
        {
            InitializeComponent();
        }

        private void ClosePage(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}