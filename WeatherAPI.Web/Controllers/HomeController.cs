using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeatherAPI.Data.OpenWeatherAPIModels;
using WeatherAPI.Web.Models;

namespace WeatherAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await WeatherGET();

            return View(weather);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<CurrentWeather?> WeatherGET()
        {
            var httpClient = new HttpClient();

            var respons = await httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q=Stockholm,se&APPID=544ad375f5007cc6a734fd13b0a0f8fe");

            var weatherforecast = JsonSerializer.Deserialize<CurrentWeather>(respons);

            return weatherforecast;
        }
    }
}
