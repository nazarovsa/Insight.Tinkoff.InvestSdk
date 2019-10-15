using System;

namespace Insight.Tinkoff.Invest.Infrastructure.Exceptions
{
    public sealed class RestServiceException : Exception
    {
        public RestServiceException()
        {
        }

        public RestServiceException(string message) : base(message)
        {
        }

        public RestServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}