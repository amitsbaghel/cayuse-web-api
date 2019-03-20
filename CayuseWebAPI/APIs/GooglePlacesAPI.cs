using CayuseWebAPI.Models;
using CayuseWebAPI.Logging;
using RestSharp;
using System;
using CayuseWebAPI.APIs.RESTAPIs.Interfaces;
using System.Threading.Tasks;
using CayuseWebAPI.APIs.Interfaces;
using System.Collections.Generic;

namespace CayuseWebAPI.Shared.RESTAPIs
{
    //https://developers.google.com/maps/documentation/timezone/start?hl=en_US
    //https://developers.google.com/maps/documentation/elevation/start
    public class GooglePlacesAPI : IGooglePlacesAPI
    {
        private const string restClientStr = "https://maps.googleapis.com/maps/api";
        private const string API = "<YOUR_API_KEY>";
        private IErrorLogger _errorLogger;
        private IRestClientFactory _restClientFactory;
        private IRestRequestFactory _restRequestFactory;

        public GooglePlacesAPI(
            IErrorLogger errorLogger,
            IRestClientFactory restClientFactory,
            IRestRequestFactory restRequestFactory)
        {
            _errorLogger = errorLogger;
            _restRequestFactory = restRequestFactory;
            _restClientFactory = restClientFactory;
        }

        /// <summary>
        /// Get time zone info
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<IRestResponse<TimeZoneModel>> GetTimeZone(double latitude, double longitude)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("location", latitude + "," + longitude);
            dict.Add("timestamp", DateTime.Now.ToString("yyyyMMdd"));
            dict.Add("key", API);
            var request = _restRequestFactory.Create("timezone/json", Method.GET, dict);
            var restClient = _restClientFactory.Create(restClientStr);
            return await restClient.ExecuteGetTaskAsync<TimeZoneModel>(request);
        }

        /// <summary>
        /// get elevation info
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<IRestResponse<ElevationModel>> GetElevation(double latitude, double longitude)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("locations", latitude + "," + longitude);
            dict.Add("key", API);
            dict.Add("timestamp", DateTime.Now.ToString("yyyyMMdd"));
            var request = _restRequestFactory.Create("elevation/json", Method.GET, dict);
            var restClient = _restClientFactory.Create(restClientStr);
            return await restClient.ExecuteGetTaskAsync<ElevationModel>(request);
        }
    }
}
