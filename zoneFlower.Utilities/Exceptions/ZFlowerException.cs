using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoneFlower.Utilities.Exceptions
{
    public class ZFlowerException : Exception
    {
        public ZFlowerException()
        {
        }

        public ZFlowerException(string message)
            : base(message)
        {
        }

        public ZFlowerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
