using AutoMapper;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace pdksApi.AutoMapper
{
    public class ObjectMapper
    {
        public static IMapper Mapper => mapper.Value;

        public static IConfigurationProvider Configuration => config.Value;

        public static Lazy<IMapper> mapper = new(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });


        public static Lazy<IConfigurationProvider> config = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            return config;
        });

    }
}
