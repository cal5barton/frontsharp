using FrontSharp.Models;

namespace FrontSharp.Interfaces
{
    public interface ITagLogic
    {
        Tag CreateTag(string name);
        Tag DeleteTag(string id);
        ListResultResponseBody<Tag> ListTags();
    }
}