using FoodTok.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodTok.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public bool IsRefreshing { get; set; }

        public ObservableCollection<PostsModel> SearchResults { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SearchViewModel()
        {
            SearchResults = new ObservableCollection<PostsModel>();
            
        }

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            Console.WriteLine(query + " This is the string");
            SearchResults.Clear();
            int count = 0;

            var data = await App.FoodTokService.SearchPost(query);
            Console.WriteLine(data + "this is data");
            foreach (var item in data)
            {
                SearchResults.Add(item);
                Console.WriteLine(count++ + "this is count");
            }


        });

        
    }
}
