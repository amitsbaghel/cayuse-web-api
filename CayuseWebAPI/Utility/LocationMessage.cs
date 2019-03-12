using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CayuseWebAPI.Utility
{
    public static class LocationMessage
    { 
        /// <summary>
        /// Format message for location information 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="temp"></param>
        /// <param name="timeZone"></param>
        /// <param name="elevation"></param>
        /// <returns></returns>
        public static string Format(string location,double temp,string timeZone,double elevation)
        {
            string message = $"At the location {location}, the temperature is {temp}, the timezone is {timeZone}, and the elevation is {elevation.ToString("#.##")}";
            return message;
        }
    }
}