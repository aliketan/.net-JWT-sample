namespace API.Model.Dtos.User
{
    public class UserResponseDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
