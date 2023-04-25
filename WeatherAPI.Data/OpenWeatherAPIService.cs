﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.Data.OpenWeatherAPIModels;

namespace WeatherAPI.Data
{
    public class OpenWeatherAPIService
    {
        public async Task<CurrentWeather> GetCurrentWeather(string city)
        {
            var httpClient = new HttpClient();

            var respons = await httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID=544ad375f5007cc6a734fd13b0a0f8fe");

            var currentWeather = JsonSerializer.Deserialize<CurrentWeather>(respons);

            return currentWeather;
        }

        public async Task<WeatherForecast> GetWeatherForecast(string city)
        {
            var httpClient = new HttpClient();

            var respons = await httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid=544ad375f5007cc6a734fd13b0a0f8fe");

            var weatherforecast = JsonSerializer.Deserialize<WeatherForecast>(respons);

            return weatherforecast;
        }
    }
}
