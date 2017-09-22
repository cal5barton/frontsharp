using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class BaseResponseBody
    {
        public _Links _links { get; set; }
        public _Error _error { get; set; }
    }
}
