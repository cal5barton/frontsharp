using FrontSharp.Interfaces;
using FrontSharp.Models;
using RestSharp;

namespace FrontSharp.Logic
{
    public class TagLogic : BaseLogic, ITagLogic
    {
        public TagLogic(FrontSharpClient client)
            : base(client)
        {
            _baseRoute = "tags";
        }

        /// <summary>
        /// Creates a new tag
        /// </summary>
        /// <param name="name">The name of the tag to be created</param>
        /// <returns>Created tag details</returns>
        public Tag CreateTag(string name)
        {
            var request = base.BuildRequest(Method.POST);

            var obj = new { name = name };

            return _client.Execute<Tag>(request, obj);
        }
    }
}