using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Wheater
    {
        public List<Dictionary<string,string>> wheater { get; set; }
        public Dictionary<string,float> main { get; set; }
    }
}