using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Exceptions
{
    public class FileSizeException :Exception 
    {

        public string Property { get; set; }
        public FileSizeException(string? message, string property) : base(message)
        {
            Property = property;
        }

    }
}