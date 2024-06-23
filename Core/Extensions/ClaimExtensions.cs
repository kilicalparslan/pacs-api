using System.Collections.Generic;
using System.Security.Claims;

namespace pdksApi.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void UserId(this List<Claim> claims, string userId)
        {
            claims.Add(new Claim(ClaimTypes.Sid, userId));
        }

        public static void UserName(this List<Claim> claims, string userName)
        {
            claims.Add(new Claim(ClaimTypes.Name, userName));
        }

        public static void UserRole(this List<Claim> claims, List<string> roles)
        {
            roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));
        }
        
    }
}
