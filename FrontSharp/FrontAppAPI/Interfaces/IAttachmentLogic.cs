using FrontAppAPI.Models;

namespace FrontAppAPI.Interfaces
{
    public interface IAttachmentLogic
    {
        void Download(Attachment attachment, string destinationFolder);
    }
}