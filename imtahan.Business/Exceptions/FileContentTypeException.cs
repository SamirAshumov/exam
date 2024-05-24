using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Exceptions
{
    public class FileContentTypeException :Exception
    {
        public string Property { get; set; }
        public FileContentTypeException(string? message, string property) : base(message)
        {
            Property = property;
        }

    }
}