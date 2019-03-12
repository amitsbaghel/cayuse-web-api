using CayuseWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CayuseWebAPI.APIs.RESTAPIs.Interfaces
{
    public interface IGooglePlacesAPI
    {
        Task<IRestResponse<ElevationModel>> GetElevation(double latitude, double longitude);

        Task<IRestResponse<TimeZoneModel>> GetTimeZone(double latitude, double Longitude);
    }
}