using NewsApp.data;
using NewsApp.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;

namespace NewsApp.viewmodels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ArticleModel> Articles { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isRunning;
        private bool _isVisible;

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (value != _isRunning)
                {
                    _isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                if (value != _isVisible)
                {
                    _isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public MainPageViewModel()
        {
            var text = new FormattingString().FormattingDescription(Constants.SYMBOLS, "US seeks to change the very definition of employment under H-1B, which is popular among Indian companies.", 50);
            Articles = new ObservableCollection<ArticleModel> {
            new ArticleModel{Title="Trump administration to propose major changes in H-1B visas",
            Author="PTI",
            Description="US seeks to change the very definition of employment under H-1B, which is popular among Indian companies.",
            UrlToImage="https://img.etimg.com/thumb/msid-66269732,width-1070,height-580,imgsize-311439,overlay-economictimes/photo.jpg",
            PublishedAt="2018-10-18T09:23:34+00:00",
            DescriptionFormatted = text}
            };

            //LoadData();
        }

        private async void LoadData()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.URL)
            };
            HttpResponseMessage response = null;

            IsVisible = true;
            IsRunning = true;

            try
            {
                response = await client.GetAsync(client.BaseAddress);
            }
            catch (HttpRequestException)
            {
               
                System.Console.WriteLine($"DEBUG Network error");
            }

            IsRunning = false;
            IsVisible = false;

            if (response.IsSuccessStatusCode && response != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);
                var str = o.SelectToken(@"$.articles");
                List<ArticleModel> list = JsonConvert.DeserializeObject<List<ArticleModel>>(str.ToString());
                foreach (var article in list)
                {
                    article.DescriptionFormatted = new FormattingString().FormattingDescription(Constants.SYMBOLS, article.Description, 50);
                    Articles.Add(article);
                }
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
