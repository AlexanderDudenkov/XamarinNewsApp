using NewsApp.data;
using NewsApp.view;
using NewsApp.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private async void OnSelected(Object sender, SelectedItemChangedEventArgs args)
        {

            if (args.SelectedItem is ArticleModel article)
            {               
                await Navigation.PushAsync(new DetailPage(article));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
