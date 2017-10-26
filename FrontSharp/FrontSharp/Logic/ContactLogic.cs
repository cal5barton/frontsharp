using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class ContactLogic : BaseLogic, IContactLogic
    {
        public ContactLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "contacts";
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
    }
}
