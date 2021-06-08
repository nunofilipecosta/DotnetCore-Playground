using System;
using System.Runtime.Serialization;

namespace CostaSoftware.ErrorHandling.Web.Models
{

    [System.Serializable]
    public class SomeException : Exception
    {
        public SomeException() { }

        public SomeException(string message) : base(message) { }

        public SomeException(string message, System.Exception inner) : base(message, inner) { }

        protected SomeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
