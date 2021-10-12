using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Weather_Assistant.Util;

namespace Weather_Assistant.Services
{
    public class WeatherstackService: IWeatherstackService
    {
        private readonly string API_URL = null;
        private readonly string API_KEY = null;
        public WeatherstackService(IConfigurationRoot config)
        {
            API_URL = config.GetSection("WeatherStackURL").Value;
            API_KEY = config.GetSection("WeatherStackAPIKey").Value;
        }
        public async Task<WeatherStackResponse> GetWeatherInfo(string zipCode)
        {
            var response = await API_URL.AllowHttpStatus("200").SetQueryParams(new
            {
                access_key = API_KEY,
                query = zipCode
            }).GetAsync().ReceiveJson<WeatherStackResponse>();

            return response;
        }

    }
}
