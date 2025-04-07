using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class UserLogin : IdentityUserLogin<int>, IEntity
    {
    }
}
