using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostaSoftware.ErrorHandling.Web.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static ApiResponse<T> Succeed(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data };
        }
    }
}
