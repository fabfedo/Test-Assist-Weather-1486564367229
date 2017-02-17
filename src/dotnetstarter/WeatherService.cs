using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class WeatherService
 {
    private static string _url = "https://bc4424d0-8080-4c06-ac83-0fd95d534fac:BvHIESO7Tl@twcservice.mybluemix.net";
    public static string Url
    {
        get
        {
            // Reads are usually simple
            return _url;
        }
        set
        {
            // You can add logic here for race conditions,
            // or other measurements
            _url = value;
        }
    }
}

