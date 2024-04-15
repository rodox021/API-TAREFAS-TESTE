using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Exceptions
{
    public class MyTaskException : Exception
    {
         public MyTaskException() : base()
        { }

        public MyTaskException(string message) : base(message)
        { }

        public MyTaskException(string message, Exception innerException) : base(message, innerException)
        { }

      
    }
}