using FrontSharp.Models;
using FrontSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IMessageLogic
    {
        ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message);
    }
}
