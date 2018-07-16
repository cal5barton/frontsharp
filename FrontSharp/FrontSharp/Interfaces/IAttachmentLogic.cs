using FrontSharp.Models;

namespace FrontSharp.Interfaces
{
    public interface IAttachmentLogic
    {
        void Download(Attachment attachment, string destinationFolder);
    }
}