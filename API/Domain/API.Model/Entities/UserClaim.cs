using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class UserClaim : IdentityUserClaim<int>, IEntity
    {
    }
}
