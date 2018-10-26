using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAA.Models;

namespace Client.Requests
{
    public interface IAccountRequest
    {
        bool Register(User user);
    }
}
