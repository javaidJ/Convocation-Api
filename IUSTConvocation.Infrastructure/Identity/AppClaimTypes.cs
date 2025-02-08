using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Infrastructure.Identity
{
    public static class AppClaimTypes
    {
        public const string UserId = nameof(UserId);

        public const string UserRole = ClaimTypes.Role;

        public const string Name = nameof(Name);

        public const string UserName = nameof(UserName);

        public const string Email = nameof(Email);

        public const string Id = nameof(Id);
    }
}
