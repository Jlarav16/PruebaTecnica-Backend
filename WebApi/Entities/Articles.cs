using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Notice
    {
        public Dictionary<string, string> source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publicshedAt { get; set; }
        public string content { get; set; }
    }
    
    public class Article
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Notice> articles { get; set; }
    }
}