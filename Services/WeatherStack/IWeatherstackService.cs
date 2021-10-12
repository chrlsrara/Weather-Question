using System.Threading.Tasks;
using Weather_Assistant.Util;

namespace Weather_Assistant.Services
{
    public interface IWeatherstackService
    {
        Task<WeatherStackResponse> GetWeatherInfo(string zipCode);

    }
}
