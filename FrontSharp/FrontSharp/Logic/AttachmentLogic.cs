using FrontSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontSharp.Models;
using RestSharp;

namespace FrontSharp.Logic
{
    public class AttachmentLogic : BaseLogic, IAttachmentLogic
    {
        public AttachmentLogic(FrontSharpClient client) : base(client)
        {
            
        }
        
        public void Download(Attachment attachment, string desitnationFolder)
        {
            _baseRoute = attachment.url.Replace(_client.BaseUrl, String.Empty);
            var request = base.BuildRequest(Method.GET);
            string path = $"{desitnationFolder}/{attachment.filename}";

            _client.DownloadData(request, path);
        }

        
    }
}
