using System;

namespace WebApi.Entities
{
    public class History
    {
        public string id { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public DateTime date { get; set; }
    }
}