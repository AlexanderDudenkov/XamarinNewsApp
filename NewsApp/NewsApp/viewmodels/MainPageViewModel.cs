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
            Articles = new ObservableCollection<ArticleModel>();
            LoadData();
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
                    article.DescriptionFormatted = FormattingDescription(Constants.SYMBOLS, article.Description, 50);
                    Articles.Add(article);
                }
            }
        }

        public string FormattingDescription(char[] symbols, string desc, int descLength = 10)
        {
            int size = descLength++;

            if (!String.IsNullOrEmpty(desc))
            {
                if (desc.Length >= size)
                {
                    for (int i = size; i > 0; size--)
                    {
                        foreach (var symbol in symbols)
                        {
                            if (desc[size] == symbol)
                            {
                                var cuttedDesc = desc.Substring(0, size--);                                
                                return cuttedDesc + "...";
                            }
                        }
                    }
                }
                else
                {
                    return desc;
                }
            }
            return " ";
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
