using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Recipient : BaseResponseBody
    {
        public string handle { get; set; }
        public string role { get; set; }
    }
}
