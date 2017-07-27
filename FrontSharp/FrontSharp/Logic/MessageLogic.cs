using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class MessageLogic : BaseLogic, IMessageLogic
    {
        public MessageLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "messages/{message_id}";
        }

        public ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message)
        {
            _baseRoute = "inboxes/{inbox_id}/imported_messages";
            var request = base.BuildRequest(Method.POST);
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);
            
            return _client.Execute<ImportMessageResponse>(request, message);
        }
    }
}
