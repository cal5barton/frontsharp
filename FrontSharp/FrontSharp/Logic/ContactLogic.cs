using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;

namespace FrontSharp.Logic
{
    public class ContactLogic : BaseLogic, IContactLogic
    {
        public ContactLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "contacts";
        }

        public ListResultResponseBody<Contact> List(string q = null, string page_token = null, int? limit = null, string sort_by = null, string sort_order = null)
        {
            var request = base.BuildRequest();
            if (!string.IsNullOrEmpty(q)) request.AddParameter("q", q, ParameterType.QueryString);
            if (!string.IsNullOrEmpty(page_token)) request.AddParameter("page_token", page_token, ParameterType.QueryString);
            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);
            if (!string.IsNullOrEmpty(sort_by)) request.AddParameter("sort_by", sort_by, ParameterType.QueryString);
            if (!string.IsNullOrEmpty(sort_order)) request.AddParameter("sort_order", sort_order, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Contact>>(request);
        }

        /// <summary>
        /// Retrieve contact details for a given contact id
        /// </summary>
        /// <param name="contactId">The id reference for the contact</param>
        /// <returns>Contact metadata</returns>
        public Contact Get(string contactId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{contactId}";
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);

            return _client.Execute<Contact>(request);
        }

        public void Update(string contactId, UpdateContactRequest updateContact)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{contactId}";
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);

            _client.Execute<Contact>(request, updateContact);
        }

        public Contact Create(CreateContactRequest contact)
        {
            var request = base.BuildRequest(Method.POST);

            return _client.Execute<Contact>(request, contact);
        }


        #region Contact Handles

        public void AddHandle(string contactId, AddHandleRequest addHandle)
        {
            var request = base.BuildRequest(Method.POST);
            request.Resource += "/{contactId}/handles";
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);

            _client.Execute<ContactHandle>(request, addHandle);
        }

        public void DeleteHandle(string contactId, DeleteHandleRequest deleteHandle)
        {
            var request = base.BuildRequest(Method.DELETE);
            request.Resource += "/{contactId}/handles";
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);

            _client.Execute<ContactHandle>(request, deleteHandle);
        }

        #endregion
    }
}