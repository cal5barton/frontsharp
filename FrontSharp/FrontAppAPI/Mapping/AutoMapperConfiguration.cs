using AutoMapper;
using FrontAppAPI.Requests;

namespace FrontAppAPI.Mapping
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