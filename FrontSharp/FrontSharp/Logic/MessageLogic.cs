using AutoMapper;
using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrontSharp.Logic
{
    public class MessageLogic : BaseLogic, IMessageLogic
    {
        public MessageLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "messages/{message_id}";
        }

        /// <summary>
        /// Appends a new message into an inbox
        /// </summary>
        /// <param name="inboxId">The id of the requested inbox</param>
        /// <param name="message">The details of the message to be imported</param>
        /// <returns>The conversation reference to the newly created conversation</returns>
        public ImportMessageResponse ImportMessage(string inboxId, ImportMessageRequest message)
        {
            _baseRoute = "inboxes/{inbox_id}/imported_messages";

            var request = base.BuildRequest(Method.POST);
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);

            if (message.HasAttachments())
            {
                var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Mapper.Map<ImportMessageMultipartFormRequest>(message), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                foreach (var p in parameters)
                {
                    request.AddParameter(p.Key.ToString(), p.Value);
                }

                for (int i = 0; i < message.Attachments.Count(); i++)
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

        public SendNewMessageResponse SendNewMessage(string channelId, SendNewMessageRequest message)
        {
            _baseRoute = "channels/{channel_id}/messages";

            var request = base.BuildRequest(Method.POST);
            request.AddParameter("channel_id", channelId, ParameterType.UrlSegment);

            if (message.HasAttachments())
            {
                var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Mapper.Map<SendReplyMultipartFormRequest>(message), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                foreach (var p in parameters)
                {
                    request.AddParameter(p.Key.ToString(), p.Value);
                }

                for (int i = 0; i < message.Attachments.Count(); i++)
                {
                    var attach = message.Attachments[i];
                    var file = File.ReadAllBytes(attach.Path);
                    var fileParam = FileParameter.Create($"attachments[{i}]", file, attach.Name, attach.ContentType);
                    request.Files.Add(fileParam);
                }
                request.AlwaysMultipartFormData = true;
                return _client.Execute<SendNewMessageResponse>(request);
            }
            else
            {
                return _client.Execute<SendNewMessageResponse>(request, message);
            }
        }

        public SendReplyResponse SendReply(string conversationId, SendReplyRequest message)
        {
            _baseRoute = "conversations/{conversation_id}/messages";

            var request = base.BuildRequest(Method.POST);
            request.AddParameter("conversation_id", conversationId, ParameterType.UrlSegment);

            if (message.HasAttachments())
            {
                var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Mapper.Map<SendReplyMultipartFormRequest>(message), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                foreach (var p in parameters)
                {
                    request.AddParameter(p.Key.ToString(), p.Value);
                }

                for (int i = 0; i < message.Attachments.Count(); i++)
                {
                    var attach = message.Attachments[i];
                    var file = File.ReadAllBytes(attach.Path);
                    var fileParam = FileParameter.Create($"attachments[{i}]", file, attach.Name, attach.ContentType);
                    request.Files.Add(fileParam);
                }
                request.AlwaysMultipartFormData = true;
                return _client.Execute<SendReplyResponse>(request);
            }
            else
            {
                return _client.Execute<SendReplyResponse>(request, message);
            }
        }
    }
}