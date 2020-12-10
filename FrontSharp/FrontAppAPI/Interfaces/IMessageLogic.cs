using FrontAppAPI.Models;
using FrontAppAPI.Requests;

namespace FrontAppAPI.Interfaces
{
    public interface IMessageLogic
    {
        ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message);

        SendReplyResponse SendReply(string conversationId, SendReplyRequest message);
    }
}