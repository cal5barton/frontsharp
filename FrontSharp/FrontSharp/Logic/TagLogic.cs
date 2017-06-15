using FrontSharp.Interfaces;
using FrontSharp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class TagLogic : BaseLogic, ITagLogic
    {
        public TagLogic(FrontSharpClient client)
            : base(client)
        {
            _baseRoute = "tags";
        }

        public Tag CreateTag(string name)
        {
            var request = new RestRequest();
            request.Resource = _baseRoute;
            request.Method = Method.POST;

            //Create anonymous object with data. API returning failure response unless this is anonymous for whatever reason
            var obj = new { name = name};

            var response = _client.Execute<Tag>(request, obj);

            return response;
        }
    }
}
