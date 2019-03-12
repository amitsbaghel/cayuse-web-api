using CayuseWebAPI.APIs.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CayuseWebAPI.APIs
{
    public class RestRequestFactory : IRestRequestFactory
    {
        public RestRequest Create(string url, Method method,Dictionary<string,string> dict)
        {
            var request = new RestRequest(url, method);
            foreach (var key in dict.Keys)
            {
                request.AddParameter(key,dict[key]);
            }
            return request;
        }
    }
}