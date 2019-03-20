using CayuseWebAPI.Models;
using CayuseWebAPI.Logging;
using RestSharp;
using CayuseWebAPI.APIs.RESTAPIs.Interfaces;
using System.Threading.Tasks;
using CayuseWebAPI.APIs.Interfaces;
using System.Collections.Generic;

namespace CayuseWebAPI.Shared.RESTAPIs
{
    //https://openweathermap.org/current
    public class WeatherAPI : IWeatherAPI
    {
        private const string restClientStr = "http://api.openweathermap.org/data/2.5";
        private const string API = "<YOUR_API_KEY>";
        private IErrorLogger _errorLogger;
        private IRestClientFactory _restClientFactory;
        private IRestRequestFactory _restRequestFactory;

        public WeatherAPI(IErrorLogger errorLogger,
            IRestClientFactory restClientFactory,
            IRestRequestFactory restRequestFactory)
        {
            _errorLogger = errorLogger;
            _restRequestFactory = restRequestFactory;
            _restClientFactory = restClientFactory;
        }

        /// <summary>
        /// Get weather data by zipcode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>WeatherModel</returns>
        public async Task<IRestResponse<WeatherModel>> GetWeatherByZIPCode(string zipCode)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("zip", zipCode);
            dict.Add("APPID", API);
            dict.Add("units", "imperial");
            var request = _restRequestFactory.Create("weather", Method.GET, dict);
            var restClient = _restClientFactory.Create(restClientStr);
            return await restClient.ExecuteGetTaskAsync<WeatherModel>(request);

        }
    }
}
