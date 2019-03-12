using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CayuseWebAPI.Logging
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessage);
    }
}