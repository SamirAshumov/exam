using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Exceptions
{
    public class EntityNotFoundException : Exception
    { 
        public string Property { get; set; }
        public EntityNotFoundException(string? message, string property) : base(message)
        {
            Property = property;
        }

    }
}