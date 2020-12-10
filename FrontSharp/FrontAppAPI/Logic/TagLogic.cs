using FrontAppAPI.Interfaces;
using FrontAppAPI.Models;
using RestSharp;

namespace FrontAppAPI.Logic
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


        /// <summary>
        /// Deletes a tag
        /// </summary>
        /// <param tagId="tagId">The tag id to be deleted</param>
        /// <returns>Deleted tag details</returns>
        public Tag DeleteTag(string tagId)
        {
            var request = base.BuildRequest(Method.DELETE);

            request.Resource += "/{tag_id}";
            request.AddParameter("tag_id", tagId, ParameterType.UrlSegment);

            return _client.Execute<Tag>(request);
        }

        /// <summary>
        /// List Tags
        /// </summary>
        /// <returns>Return a list of tags</returns>
        public ListResultResponseBody<Tag> ListTags()
        {
            var request = base.BuildRequest(Method.GET);

            return _client.Execute<ListResultResponseBody<Tag>>(request);
        }
    }
}