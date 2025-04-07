using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class User : IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
