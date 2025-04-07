using System.ComponentModel;

namespace API.Model.Dtos.User
{
    public class ChangePasswordDto
    {
        public int Id { get; set; }

        public string CurrentPassword { get; set; }

        [Description("The password must be minimum 6 characters and contain, one uppercase digit and one digit.")]
        public string NewPassword { get; set; }
    }
}
