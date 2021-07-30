using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Common.ExceptionHandling
{
    public class CustomErrorException : Exception
    {
        public CustomErrorException(
           int error = 0,
           HttpStatusCode statusCode = HttpStatusCode.BadRequest,
           string description = null)
        {
            this.Error = error;
            this.StatusCode = statusCode;
            this.Description = description;
        }

        /// <summary>Gets the error.</summary>
        public int Error { get; }

        /// <summary>Gets the status code.</summary>
        public HttpStatusCode StatusCode { get; }

        public string Description { get; }
    }
}
