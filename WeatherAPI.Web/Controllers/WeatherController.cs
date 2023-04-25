using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Data;
using WeatherAPI.Data.OpenWeatherAPIModels;

namespace WeatherAPI.Web.Controllers
{
    public class WeatherController : Controller
    {
        private readonly OpenWeatherAPIService _apiService;

        public WeatherController(OpenWeatherAPIService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Current(string id)
        {
            var city = id == null ? "Stockholm" : id;

            var currentWeather = await _apiService.GetCurrentWeather(city);

            return View(currentWeather);
        }

        public async Task<IActionResult> Forecast(string id)
        {
            var city = id == null ? "Stockholm" : id;

            var forecast = await _apiService.GetWeatherForecast(city);

            return View(forecast);
        }
    }
}
