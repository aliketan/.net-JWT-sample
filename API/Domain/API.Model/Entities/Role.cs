using Microsoft.AspNetCore.Identity;

namespace API.Model.Entities
{
    using Contracts;

    public class Role : IdentityRole<int>, IEntity {}
}
