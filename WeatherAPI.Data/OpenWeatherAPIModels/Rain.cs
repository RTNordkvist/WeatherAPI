﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Data.OpenWeatherAPIModels
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double _3h { get; set; }
    }
}
