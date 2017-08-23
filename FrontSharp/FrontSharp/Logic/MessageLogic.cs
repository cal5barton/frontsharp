using AutoMapper;
using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class MessageLogic : BaseLogic, IMessageLogic
    {
        public MessageLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "messages/{message_id}";
        }

        public ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message)
        {
            _baseRoute = "inboxes/{inbox_id}/imported_messages";

            var request = base.BuildRequest(Method.POST);
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);
            
            if(message.HasAttachments())
            {
                var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Mapper.Map<ImportMessageMultipartFormRequest>(message), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                foreach(var p in parameters)
                {
                    request.AddParameter(p.Key.ToString(), p.Value);
                }

                for(int i = 0; i < message.Attachments.Count(); i++)
                {
                    var attach = message.Attachments[i];
                    var file = File.ReadAllBytes(attach.Path);
                    var fileParam = FileParameter.Create($"attachments[{i}]", file, attach.Name, attach.ContentType);
                    request.Files.Add(fileParam);
                }
                request.AlwaysMultipartFormData = true;
                return _client.Execute<ImportMessageResponse>(request);
            }
            else
            {
                return _client.Execute<ImportMessageResponse>(request, message);
            }
        }
    }

}
