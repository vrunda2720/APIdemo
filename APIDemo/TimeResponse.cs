using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class TimeResponse
    {
        public string error { get; set; }
        public string error_message { get; set; }
        public string time { get; set; }
        public string timezone { get; set; }
        public double offset { get; set; }
        public string daylight_savings { get; set; }
    }
}
