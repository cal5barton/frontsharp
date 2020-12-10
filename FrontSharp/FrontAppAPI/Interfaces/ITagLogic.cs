using FrontAppAPI.Models;

namespace FrontAppAPI.Interfaces
{
    public interface ITagLogic
    {
        Tag CreateTag(string name);
        Tag DeleteTag(string id);
        ListResultResponseBody<Tag> ListTags();
    }
}