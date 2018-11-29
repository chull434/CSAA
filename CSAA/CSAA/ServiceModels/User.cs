using CSAA.Enums;

namespace CSAA.ServiceModels
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public byte [] UserImage { get; set; }

        public bool product_owner { get; set; }
        public bool scrum_master { get; set; }
        public bool developer { get; set; }

        public delegate void OnChange(User user);

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
