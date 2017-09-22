using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class ListResultResponseBody<T> where T : class
    {
        private List<_Error> _listOfErrors = new List<_Error>();
        public _Pagination _pagination { get; set; }
        public _Links _links { get; set; }
        public List<T> _results { get; set; }
        public List<_Error> _errors { get { return _listOfErrors; } set { _listOfErrors = value; } }

        [JsonProperty("_error")]
        private _Error _error { set { _listOfErrors.Add(value); } }

    }
}
