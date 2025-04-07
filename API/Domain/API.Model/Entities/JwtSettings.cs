using API.Model.Contracts;

namespace API.Model.Entities
{
    public class JwtSettings:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int DurationInMinutes { get; set; }

        public bool IsActive { get; set; }
    }
}
