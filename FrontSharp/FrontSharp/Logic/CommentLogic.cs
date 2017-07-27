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
    public class CommentLogic : BaseLogic, ICommentLogic
    {

        public CommentLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "conversations/{conversationId}/comments";
        }

        public Comment Create(string conversationId, CreateCommentRequest comment)
        {
            var request = base.BuildRequest(Method.POST);
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<Comment>(request, comment);
        }
    }
}
