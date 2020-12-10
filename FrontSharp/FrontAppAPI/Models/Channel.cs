﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAppAPI.Models
{
    public class Channel : BaseResponseBody
    {
        public string id { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string send_as { get; set; }
        public bool is_private { get; set; }
    }
}