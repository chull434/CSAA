namespace CSAA.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool product_owner { get; set; }
        public bool scrum_master { get; set; }
        public bool developer { get; set; }
    }
}
