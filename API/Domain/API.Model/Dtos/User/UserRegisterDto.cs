using System.ComponentModel;

namespace API.Model.Dtos.User
{
    public class UserRegisterDto
    {
        [Description("User first name")]
        public string FirstName { get; set; }

        [Description("User last name")]
        public string LastName { get; set; }

        [Description("User e-mail address")]
        public string Email { get; set; }

        [Description("The password must be minimum 6 characters and contain, one uppercase digit and one digit.")]
        public string Password { get; set; }

        [Description("User roles. Available roles: Administrator, Customer")]
        public string[] Roles { get; set; }
    }
}
