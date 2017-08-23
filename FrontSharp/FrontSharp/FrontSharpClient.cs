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
using RestSharp.Extensions;
using FrontSharp.Mapping;

namespace FrontSharp
{
    public class FrontSharpClient
    {
        private string _baseUrl;
        private string _token;

        
        public string BaseUrl { get => _baseUrl; set => _baseUrl = value; }

        public FrontSharpClient() : this(ConfigurationManager.AppSettings["FrontAPIEndpoint"].ToString(),ConfigurationManager.AppSettings["FrontAPIToken"].ToString())
        {
            
        }

        public FrontSharpClient(string baseUrl, string token)
        {
            //Initialize Automapper
            AutoMapperConfiguration.Configure();

            this.BaseUrl = baseUrl;
            this._token = token;
            this.Attachments = new AttachmentLogic(this);
            this.Comments = new CommentLogic(this);
            this.Contacts = new ContactLogic(this);
            this.Conversations = new ConversationLogic(this);
            this.Inboxes = new InboxLogic(this);
            this.Messages = new MessageLogic(this);
            this.Tags = new TagLogic(this);
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

        public void DownloadData(RestRequest request, string path)
        {
            try
            {
                var client = CreateClient(_baseUrl);
                client.Authenticator = new JwtAuthenticator(_token); // used on every request
                request.RootElement = "";
                client.DownloadData(request).SaveAs(path);
            }
            catch(Exception ex)
            {
                //Throw Error if Exception Occurred (Usually network issues)
                const string message = "Error retrieving response.  Check inner details for more info.";
                var webApiException = new ApplicationException(message, ex);
                throw webApiException;
            }

        }

        public IAttachmentLogic Attachments { get; private set; }
        public ICommentLogic Comments { get; private set; }
        public IContactLogic Contacts { get; private set; }
        public IConversationLogic Conversations { get; private set; }
        public IInboxLogic Inboxes { get; private set; }
        public IMessageLogic Messages { get; private set; }
        public ITagLogic Tags { get; private set; }
        
    }
}
