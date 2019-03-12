using CayuseWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CayuseWebAPI.APIs.RESTAPIs.Interfaces
{
    public interface IWeatherAPI
    {
        Task<IRestResponse<WeatherModel>> GetWeatherByZIPCode(string zipCode);
    }
}