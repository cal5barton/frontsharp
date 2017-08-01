using FrontSharp.Models;
using FrontSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IContactLogic
    {
        Contact Get(string contactId);
    }
}
