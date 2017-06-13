using FrontSharp.Interfaces;
using FrontSharp.Logic;
using FrontSharp.Requests;
using FrontSharp.Serializers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp
{
    public class FrontSharpClient
    {
        private string _baseUrl;
        private string _token;

        

        public FrontSharpClient() : this(ConfigurationManager.AppSettings["FrontAPIEndpoint"].ToString(),ConfigurationManager.AppSettings["FrontAPIToken"].ToString())
        {
            
        }

        public FrontSharpClient(string baseUrl, string token)
        {
            this._baseUrl = baseUrl;
            this._token = token;
            this.Comments = new CommentLogic(this);
        }

        //Sets RestSharp to use JSON.Net for Deserialization
        private RestClient CreateClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);

            client.ClearHandlers();

            // Override with Newtonsoft JSON Handler
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);

            return client;
        }

        public T Execute<T>(RestRequest request, object objToBeSerialized = null, NewtonsoftJsonSerializer serializer = null) where T : new()
        {
            //Set Defaults for request
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = serializer != null ? serializer : NewtonsoftJsonSerializer.Default;
            request.AddHeader("Content-Type", "application/json");
            if (objToBeSerialized != null) request.AddJsonBody(objToBeSerialized);

            var client = CreateClient(_baseUrl);
            client.Authenticator = new JwtAuthenticator(_token); // used on every request
            request.RootElement = "";
            
            var response = client.Execute<T>(request);

            //Throw Error if Exception Occurred (Usually network issues)
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var webApiException = new ApplicationException(message, response.ErrorException);
                throw webApiException;
            }
            return response.Data;
        }

        public ICommentLogic Comments { get; private set; }
    }
}
