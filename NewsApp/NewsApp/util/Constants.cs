using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.util
{
    class Constants
    {
        private static Constants instance;
        private Constants() { }

        public static Constants getInstance()
        {
            if (instance == null)
                instance = new Constants();
            return instance;
        }

        public string url = "https://newsapi.org/v2/top-headlines?sources=google-news&apiKey=f74ef05b6a3548c19183980c5a90c444";
    }
}
