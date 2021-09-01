using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Weather
    {
        public List<Dictionary<string,string>> wheater { get; set; }
        public Dictionary<string,float> main { get; set; }
        public Dictionary<string,float> wind { get; set; }
        public Dictionary<string, string> sys { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}