using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class UserToken : IdentityUserToken<int>, IEntity
    {
    }
}
