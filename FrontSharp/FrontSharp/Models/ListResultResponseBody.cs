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
        private List<Error> _listOfErrors = new List<Error>();
        public Pagination _pagination { get; set; }
        public Links _links { get; set; }
        public List<T> _results { get; set; }
        public List<Error> _errors { get { return _listOfErrors; } set { _listOfErrors = value; } }

        [JsonProperty("_error")]
        private Error _error { set { _listOfErrors.Add(value); } }

    }
}
