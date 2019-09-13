using FrontSharp.Models;
using FrontSharp.Requests;

namespace FrontSharp.Interfaces
{
    public interface IContactLogic
    {
        ListResultResponseBody<Contact> List(string q = null, string page_token = null, int? limit = null, string sort_by = null, string sort_order = null);

        Contact Get(string contactId);

        void Update(string contactId, UpdateContactRequest updateContact);

        Contact Create(CreateContactRequest contact);


        void AddHandle(string contactId, AddHandleRequest addHandle);

        void DeleteHandle(string contactId, DeleteHandleRequest deleteHandle);
    }
}