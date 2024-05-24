using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Exceptions
{
    public class FileRequiredException : Exception
    {

        public string Property { get; set; }
        public FileRequiredException(string? message, string property) : base(message)
        {
            Property = property;
        }

    }
}
