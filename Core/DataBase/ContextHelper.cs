using pdksApi.Core.Enums;
using pdksApi.Core.Utilities.IoC;

namespace pdksApi.Core.AppHelpers.Database
{
    public static class ContextHelper
    {
        public static IConfiguration Configuration { get; set; }
        public static string GetConnectionString(ConnectionStringType connectionStringType)
        {
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var connectionStringOptions = Configuration?.GetSection("ConnectionStringOptions").Get<ConnectionStringOptions>();
            var connectionString = string.Empty;
            if (connectionStringOptions == null) return connectionString;
            if (connectionStringOptions.ProductionDbConnectionString != null/* || connectionStringOptions.TestConnectionString != null*/)
            {
                connectionString = connectionStringType switch
                {
                    ConnectionStringType.ProductionDb => connectionStringOptions.ProductionDbConnectionString,
                    //ConnectionStringType.TestDb => connectionStringOptions.TestConnectionString,
                    _ => connectionString
                };
            }          
            
            return connectionString;
        }

    }
}
