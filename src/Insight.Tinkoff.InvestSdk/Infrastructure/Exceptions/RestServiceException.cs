using System;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Exceptions
{
    public sealed class RestServiceException : Exception
    {
        public ErrorResponse ErrorResponse { get; }
        
        public RestServiceException()
        {
        }

        public RestServiceException(string message) : base(message)
        {
        }
        
        public RestServiceException(string message, ErrorResponse response) : base(message)
        {
            ErrorResponse = response;
        }

        public RestServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}