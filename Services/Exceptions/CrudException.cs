using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class CrudException : Exception
    {
        private HttpStatusCode notFound;
        private string v;

        public HttpStatusCode Status { get; private set; }
        public string Error { get; set; }

        public CrudException(HttpStatusCode status, string msg, string error) : base(msg)
        {
            Status = status;
            Error = error;
        }

        public CrudException(HttpStatusCode notFound, string v)
        {
            this.notFound = notFound;
            this.v = v;
        }
    }
}
