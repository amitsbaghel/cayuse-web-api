using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayuseWebAPI.APIs.Interfaces
{
    public interface IRestClientFactory
    {
        RestClient Create(string baseUrl);
    }
}
