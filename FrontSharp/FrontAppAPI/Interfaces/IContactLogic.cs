using FrontAppAPI.Models;

namespace FrontAppAPI.Interfaces
{
    public interface IContactLogic
    {
        Contact Get(string contactId);
    }
}