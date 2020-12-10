using FrontAppAPI.Interfaces;
using FrontAppAPI.Models;
using RestSharp;
using System;

namespace FrontAppAPI.Logic
{
    public class AttachmentLogic : BaseLogic, IAttachmentLogic
    {
        public AttachmentLogic(FrontSharpClient client) : base(client)
        {
        }

        /// <summary>
        /// Download the provided attachment from a message to a specified destination
        /// </summary>
        /// <param name="attachment">The metadata of the attached object including the filename, url, content type, and size</param>
        /// <param name="destinationFolder">The local destination to download the attachment to</param>
        public void Download(Attachment attachment, string destinationFolder)
        {
            _baseRoute = attachment.url.Replace(_client.BaseUrl, String.Empty);
            var request = base.BuildRequest(Method.GET);
            string path = $"{destinationFolder}/{attachment.filename}";

            _client.DownloadData(request, path);
        }
    }
}