using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    interface IProjectTeamMemberService
    {
        void AddTeamMember(string email, string projectId);
    }
}
