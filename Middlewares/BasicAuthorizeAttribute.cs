using Microsoft.AspNetCore.Authorization;

namespace pdksApi.Middlewares
{
    public class BasicAuthorizeAttribute:AuthorizeAttribute
    {
        public BasicAuthorizeAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
