using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomRouting.Web
{
    public class RouteManager
    {
        private IDictionary<string, MethodInfo> _routes = new Dictionary<string, MethodInfo>();

        public RouteManager AddRoute(Action<RouteSettings> setup)
        {
            var routeSettings = new RouteSettings();
            setup(routeSettings);

            string routeKey = $"{routeSettings.Action} {routeSettings.URL}";

            var endpointMethod = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.Equals(routeSettings.Controller))
                .GetMethod(routeSettings.Endpoint);

            _routes.Add(routeKey, endpointMethod);

            return this;
        }

        public MethodInfo Resolve(string action, string url)
        {
            if(url.StartsWith("/"))
            {
                url = url.Remove(0, 1);
            }

            string routeKey = $"{action} {url}";
            if(_routes.TryGetValue(routeKey, out MethodInfo methodInfo))
            {
                return methodInfo;
            }

            throw new Exception($"No matching route for {routeKey}");


        }
    }
}


