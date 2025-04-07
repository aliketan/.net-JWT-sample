namespace API.Model.Dtos.Jwt
{
    public class CreateTokenDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
