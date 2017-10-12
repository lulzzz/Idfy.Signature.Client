using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idfy.Signature.Client
{
    public class ApiResponseException : Exception
    {
        public ApiResponseException(int statusCode, string reasonPhrase, string message) : base(message)
        {
            this.StatusCode = statusCode;
            this.ReasonPhrase = reasonPhrase;
        }
        public int StatusCode { get; }
        public string ReasonPhrase { get; }

    }
}
