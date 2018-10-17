using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.util
{
     class Constants
    {
        private static Constants _Instance;
        private Constants() { }

        public static Constants GetInstance()
        {
            if (_Instance == null)
                _Instance = new Constants();
            return _Instance;
        }

        public static string URL = "https://newsapi.org/v2/top-headlines?sources=google-news&apiKey=f74ef05b6a3548c19183980c5a90c444";
    }
}
