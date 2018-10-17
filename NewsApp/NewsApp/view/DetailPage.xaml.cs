using NewsApp.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        public DetailPage(ArticleModel article)
        {
            InitializeComponent();
            _title.Text = article.Title;
            _image.Source = article.UrlToImage;
            _description.Text = article.Description;          
            _author.Text = article.Author;
            _publishedAt.Text = article.PublishedAt;
        }
    }
}