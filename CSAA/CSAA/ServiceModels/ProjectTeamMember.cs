using System;
using CSAA.Enums;

namespace CSAA.ServiceModels
{
    public class ProjectTeamMember
    {
        public string Id { get; set; }
        public string UserId{ get; set; }
        public string ProjectId { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ProjectTitle { get; set; }

        public delegate void OnChange(ProjectTeamMember projectTeamMember);

        public OnChange OnRoleChange;

        private Role _role;
        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
                OnRoleChange?.Invoke(this);
            }
        }
    }
}