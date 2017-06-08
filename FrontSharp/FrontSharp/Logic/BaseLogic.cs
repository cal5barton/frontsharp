using FrontSharp.Serializers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class BaseLogic
    {
        protected FrontSharpClient _client;
        protected string _baseRoute;
        
        public BaseLogic(FrontSharpClient client)
        {
            _client = client;
        }

    }
}
