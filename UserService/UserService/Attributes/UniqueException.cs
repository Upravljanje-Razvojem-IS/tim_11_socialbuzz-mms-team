using System;
using System.Globalization;

namespace UserService.Attributes
{
    public class UniqueException : Exception
    {
        public UniqueException() : base() { }
        public UniqueException(string message) : base(message) { }
        public UniqueException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
