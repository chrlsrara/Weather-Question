namespace Weather_Assistant.Util
{
    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class CurrentWeather
    {
        public string observation_time { get; set; }
        public string temperature { get; set; }
        public string weather_code { get; set; }
        public string[] weather_descriptions { get; set; }
        public int wind_speed { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public string pressure { get; set; }
        public string precip { get; set; }
        public string humidity { get; set; }
        public double uv_index { get; set; }
        public string visibility { get; set; }
    }

    public class WeatherStackResponse
    {
        public Location location { get; set; }
        public CurrentWeather current { get; set; }
    }
}
