using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class ListResult<T> where T : class
    {
        public _Pagination _pagination { get; set; }
        public _Links _links { get; set; }
        public List<T> _results { get; set; }
    }
}
