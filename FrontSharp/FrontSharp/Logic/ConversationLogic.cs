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
    public class ConversationLogic : BaseLogic, IConversationLogic
    {

        public ConversationLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "conversations";
        }
        
        public Conversation Get(string conversationId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<Conversation>(request);
        }

        public void Update(string conversationId, UpdateConversationRequest updateConversation)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);


            //Create anonymous object with data. API returning failure response unless this is anonymous for whatever reason
            var obj = new { assignee_id = updateConversation.AssigneeId, inbox_id = updateConversation.InboxId, status = updateConversation.Status, tags = updateConversation.Tags }; 

            _client.Execute<Conversation>(request, obj);
        }
    }
}
