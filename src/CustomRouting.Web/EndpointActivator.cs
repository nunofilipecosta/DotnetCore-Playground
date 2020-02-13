using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomRouting.Web
{
    public class EndpointActivator
    {
        public async Task<object> ActivateAsync(MethodInfo endpointMethod, string requestBody)
        {
            // create an instance of the controller
            var controllerType = endpointMethod.DeclaringType;
            var controller = Activator.CreateInstance(controllerType);

            var endpointParameter = endpointMethod.GetParameters().FirstOrDefault();

            if (endpointParameter is null)
            {
                var endpointResponse = endpointMethod.Invoke(controller, null);
                var response = await IfAsync(endpointResponse);
                return response;
            }
            else
            {
                var requestBodyParameter = DeserializeRequestBody(requestBody, endpointParameter);
                var endpointResponse = endpointMethod.Invoke(controller, new object[] { requestBodyParameter });
                var response = await IfAsync(endpointResponse);
                return response;
            }
        }

        private static object DeserializeRequestBody(string requestBody, ParameterInfo endpointParameter)
        {
            var deserializedParamter = JsonConvert.DeserializeObject(requestBody, endpointParameter.ParameterType);

            if (deserializedParamter is null)
            {
                throw new ArgumentException($"Unable to deserialze request body to type {endpointParameter.ParameterType.Name}");
            }

            return deserializedParamter;
        }

        private static async Task<object> IfAsync(object endpointResponse)
        {
            var responseTask = endpointResponse as Task;

            if (responseTask is null)
            {
                return endpointResponse;
            }

            await responseTask;

            var responseTaskResult = responseTask.GetType()
                .GetProperty("Result")
                .GetValue(responseTask);

            return responseTaskResult;
        }
    }
}
