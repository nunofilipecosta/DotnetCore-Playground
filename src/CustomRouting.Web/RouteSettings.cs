using System;

namespace CustomRouting.Web
{
    public class RouteSettings
    {
        public string URL { get; set; }
        public string Action { get; set; }
        public Type Controller { get; set; }
        public string Endpoint { get; set; }
    }
}


