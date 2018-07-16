using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FrontSharp.Models
{
    public class ListResultResponseBody<T> where T : class
    {
        private List<Error> _listOfErrors = new List<Error>();

        [JsonProperty("_pagination")]
        private Pagination _pagination { get; set; }

        public Links _links { get; set; }
        public List<T> _results { get; set; }
        public List<Error> _errors { get { return _listOfErrors; } set { _listOfErrors = value; } }

        [JsonProperty("_error")]
        private Error _error { set { _listOfErrors.Add(value); } }

        public ListResultResponseBody<T> NextPage(FrontSharpClient client)
        {
            if (_pagination != null && !String.IsNullOrEmpty(_pagination.next))
            {
                return client.ExecuteURL<ListResultResponseBody<T>>(_pagination.next);
            }
            return null;
        }

        public ListResultResponseBody<T> PreviousPage(FrontSharpClient client)
        {
            if (_pagination != null && !String.IsNullOrEmpty(_pagination.prev))
            {
                return client.ExecuteURL<ListResultResponseBody<T>>(_pagination.prev);
            }
            return null;
        }
    }
}