using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CustomRouting.Web
{
    public static class CustomRoutingMiddleware
    {
        private static RouteManager _routeManager = new RouteManager();
        private static EndpointActivator _endpointActivator = new EndpointActivator();

        public static RouteManager UseCustomRouting(this IApplicationBuilder app)
        {
            // Add TryProcess() to request pipeline
            app.Use(async (context, next) =>
            {
                await TryProcess(context);
            });

            return _routeManager;
        }

        public static async Task TryProcess(HttpContext context)
        {
            try
            {
                // get endpoint method
                var endpointMethod = _routeManager.Resolve(context.Request.Method, context.Request.Path);

                // read request body
                string requestBody = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();

                // activate the endpoint
                var response = await _endpointActivator.ActivateAsync(endpointMethod, requestBody);

                // serialize the response
                var serializedResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

                // return response to client
                await context.Response.WriteAsync(serializedResponse);
            }
            catch (Exception error)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(error.Message);
            }
        }
    }
}
