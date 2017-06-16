using FrontSharp.Models;
using FrontSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IConversationLogic
    {
        Conversation Get(string conversationId);
        void Update(string conversationId, UpdateConversationRequest updateConversation);
    }
}
