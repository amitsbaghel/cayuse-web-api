using CayuseWebAPI.Models;
using CayuseWebAPI.Logging;
using CayuseWebAPI.Utility;
using System.Web.Http;
using CayuseWebAPI.APIs.RESTAPIs.Interfaces;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace CayuseWebAPI.Controllers
{ 
    public class LocationController : ApiController
    {
        private IErrorLogger _errorLogger;
        private IWeatherAPI _weatherAPI;
        private IGooglePlacesAPI _googlePlacesAPI;
        
        public LocationController(
            IErrorLogger errorLogger,
            IGooglePlacesAPI googlePlacesAPI,
            IWeatherAPI weatherAPI

            )
        {
            _errorLogger = errorLogger;
            _googlePlacesAPI = googlePlacesAPI;
            _weatherAPI = weatherAPI;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string zipCode)
        {
            // weather API
            var weatherResponse = await _weatherAPI.GetWeatherByZIPCode(zipCode);

            if(!weatherResponse.IsSuccessful)
                return Content(HttpStatusCode.NotFound,"Location not found");

            var latitude = weatherResponse.Data.coord.lat;
            var longitude = weatherResponse.Data.coord.lon;
            var location = weatherResponse.Data.name;
            var temp = weatherResponse.Data.main.temp;

            // time zone API
            Task<IRestResponse<TimeZoneModel>> timeZoneTask = _googlePlacesAPI.GetTimeZone(latitude, longitude);
            
            // elevation API
            Task<IRestResponse<ElevationModel>> elevationTask  = _googlePlacesAPI.GetElevation(latitude, longitude);
     
            await Task.WhenAll(timeZoneTask, elevationTask);

            if(!(timeZoneTask.Result.IsSuccessful && elevationTask.Result.IsSuccessful))
                return Content(HttpStatusCode.NotFound, "Location not found");

            var timeZone= timeZoneTask.Result.Data.timeZoneName;
            var elevation = elevationTask.Result.Data.results[0].elevation;

            string output = LocationMessage.Format(location, temp, timeZone, elevation);

            return Content(HttpStatusCode.OK, output);
        }
    }
}