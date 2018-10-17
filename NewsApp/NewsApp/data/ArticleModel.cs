using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewsApp.data
{
    public class ArticleModel 
    {        
        public string Title { get; set; }        
        public string Author { get; set; }       
        public string Description { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }              
    }
}
