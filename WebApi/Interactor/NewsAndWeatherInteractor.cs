using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WebApi.Entities;

namespace WebApi.Interactor
{
    public class NewsAndWeatherInteractor
    {
        private static async Task<string> made_get_petition(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();

            var response = client.Get(request);

            return response.Content.ToString();
        }
        
        public static async Task<Article> news_articles(string country,string ApiKey)
        {
            string url = $"https://newsapi.org/v2/top-headlines?country={country}&apiKey={ApiKey}";
            string dataString = await made_get_petition(url);
            var data = JsonConvert.DeserializeObject<Article>(dataString);
            
            return data;
        }

        public static async Task<Weather> get_weather(string city,string ApiKey)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}";
            string dataString = await made_get_petition(url);
            var data = JsonConvert.DeserializeObject<Weather>(dataString);

            return data;
        }
        
    }
}