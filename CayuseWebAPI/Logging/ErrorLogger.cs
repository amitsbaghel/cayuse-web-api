using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CayuseWebAPI.Logging
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessage)
        {
            throw new NotImplementedException();
        }
    }
}