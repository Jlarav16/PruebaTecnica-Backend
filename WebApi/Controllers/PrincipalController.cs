using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Contexts;
using WebApi.Entities;
using WebApi.Interactor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("principal")]
    public class Principal : ControllerBase
    {
        private readonly ApiDbContext _context;
        private IConfiguration _configuration;
        public Principal(ApiDbContext context,IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        [HttpGet]
        public async Task<ActionResult<ResponseApi>> Get(string city)
        {
            if (city == null)
            {
                return BadRequest("El Campo {CITY} es Requerido.");
            }

            string OpenWeatherApiKey = this._configuration["OpenWeather:ApiKey"];
            var weather = await NewsAndWeatherInteractor.get_weather(city,OpenWeatherApiKey);
            if (weather.cod == 404)
            {
                return NotFound("No se encontro resultados para esta ciudad");
            }

            string NewsApikey = this._configuration["NewsApi:Apikey"];
            var article = await NewsAndWeatherInteractor.news_articles(weather.sys["country"],NewsApikey);

            History history = new History()
            {
                id = Guid.NewGuid().ToString(),
                city = city,
                country = weather.sys["country"],
                date = DateTime.Now
            };

            _context.History.Add(history);
            await _context.SaveChangesAsync();

            ResponseApi response = new ResponseApi()
            {
                article = article, 
                weather = weather,
            };
            return response;
        }
    }
}