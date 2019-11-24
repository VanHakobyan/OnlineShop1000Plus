using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace OnlineShop.Api.Helpers
{
    public class AppExceptions : Exception
    {
        public AppExceptions() : base() { }

        public AppExceptions(string message) : base(message) { }

        public AppExceptions(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
