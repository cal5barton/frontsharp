using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class ImportMessageResponse : BaseResponseBody
    {
        public string conversation_reference { get; set; }
        public string message_uid { get; set; }
    }
}