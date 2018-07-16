using AutoMapper;
using FrontSharp.Requests;

namespace FrontSharp.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ImportMessageRequest, ImportMessageMultipartFormRequest>();
                cfg.CreateMap<SendReplyRequest, SendReplyMultipartFormRequest>();
            });
        }
    }
}