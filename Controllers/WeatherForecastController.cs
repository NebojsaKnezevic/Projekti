using AspNetCoreWithReact.DependencyInjection;
using AspNetCoreWithReact.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private IConsoleWritter _consoleWritter;
        private ILibraService _libraService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConsoleWritter consoleWritter, ILibraService libraService)
        {
            _logger = logger;
            _consoleWritter = consoleWritter;
            _libraService = libraService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //Dep Injection
            //_consoleWritter.Write();

            //Get
            //List<Libra> libraList = _libraService.GetAll();
            //List<Libra> libraList = _libraService.GetByName("A2");

            //Save
            //_libraService.Save(new Libra() {Name="A5", Address="B5", Telephone="C5" });

            //Update
            //Libra libraUpdate = _libraService.GetByName("A222").FirstOrDefault();
            //libraUpdate.Name = "A2222";
            //_libraService.Update(libraUpdate);

            //Delete
            //_libraService.Delete(3);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}