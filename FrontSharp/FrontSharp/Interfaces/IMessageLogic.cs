using FrontSharp.Models;
using FrontSharp.Requests;

namespace FrontSharp.Interfaces
{
    public interface IMessageLogic
    {
        ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message);

        SendReplyResponse SendReply(string conversationId, SendReplyRequest message);
    }
}