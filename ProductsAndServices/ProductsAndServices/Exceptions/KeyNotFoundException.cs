using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException() : base() { }
        public KeyNotFoundException(string message) : base(message) { }
        public KeyNotFoundException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }

    }
}
