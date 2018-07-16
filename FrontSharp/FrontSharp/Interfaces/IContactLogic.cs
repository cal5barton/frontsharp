using FrontSharp.Models;

namespace FrontSharp.Interfaces
{
    public interface IContactLogic
    {
        Contact Get(string contactId);
    }
}