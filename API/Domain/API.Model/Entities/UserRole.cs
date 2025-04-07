using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class UserRole : IdentityUserRole<int>, IEntity
    {
    }
}
