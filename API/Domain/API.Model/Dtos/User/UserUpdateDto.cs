using System.ComponentModel;

namespace API.Model.Dtos.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [Description("User first name")]
        public string FirstName { get; set; }

        [Description("User last name")]
        public string LastName { get; set; }

        [Description("User e-mail address")]
        public string Email { get; set; }
    }
}
