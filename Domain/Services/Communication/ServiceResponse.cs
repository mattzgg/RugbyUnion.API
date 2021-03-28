using System;

namespace RugbyUnion.API.Domain.Services.Communication
{
    public class ServiceResponse<TResult>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public TResult Result { get; protected set; }

        protected ServiceResponse(bool success, string message, TResult result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
        public ServiceResponse(TResult result) : this(true, string.Empty, result) { }

        public ServiceResponse(string message) : this(false, message, default) { }

    }
}
