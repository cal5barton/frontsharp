using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;

namespace FrontSharp.Logic
{
    public class CommentLogic : BaseLogic, ICommentLogic
    {
        public CommentLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "conversations/{conversationId}/comments";
        }

        /// <summary>
        /// Creates a comment that is posted to the given conversation via the conversation id
        /// </summary>
        /// <param name="conversationId">Id of the requested conversation</param>
        /// <param name="comment">The comment to be created consisting of the body and author id</param>
        /// <returns>The newly created comment details including the UNIX timestamp denoting the time posted</returns>
        public Comment Create(string conversationId, CreateCommentRequest comment)
        {
            var request = base.BuildRequest(Method.POST);
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<Comment>(request, comment);
        }
    }
}