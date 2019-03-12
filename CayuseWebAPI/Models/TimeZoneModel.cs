using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CayuseWebAPI.Models
{
        public class TimeZoneModel
        {
            public int dstOffset { get; set; }
            public int rawOffset { get; set; }
            public string status { get; set; }
            public string timeZoneId { get; set; }
            public string timeZoneName { get; set; }
        }
}