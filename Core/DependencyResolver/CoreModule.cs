using pdksApi.Core.AppHelpers.Database;
using pdksApi.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace pdksApi.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public CoreModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void Load(IServiceCollection services)
        {
            services.Configure<ConnectionStringOptions>(Configuration.GetSection("ConnectionStringOptions"));
            services.AddHttpContextAccessor();
            //services.AddScoped(typeof(IGenericRepositoryBase<>), typeof(GenericRepositoryBase<,>));            

            //#region Jwt token options
            //services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            //var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidIssuer = tokenOptions.Issuer,
            //        ValidAudience = tokenOptions.Audience,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
            //    };
            //});
            //#endregion
        }
    }
}
