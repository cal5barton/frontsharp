using FrontAppAPI.Models;
using FrontAppAPI.Requests;

namespace FrontAppAPI.Interfaces
{
    public interface ICommentLogic
    {
        Comment Create(string conversationId, CreateCommentRequest comment);
    }
}