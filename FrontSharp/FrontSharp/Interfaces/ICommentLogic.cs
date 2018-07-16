using FrontSharp.Models;
using FrontSharp.Requests;

namespace FrontSharp.Interfaces
{
    public interface ICommentLogic
    {
        Comment Create(string conversationId, CreateCommentRequest comment);
    }
}