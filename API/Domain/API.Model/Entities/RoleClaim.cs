using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class RoleClaim : IdentityRoleClaim<int>, IEntity
    {
    }
}
