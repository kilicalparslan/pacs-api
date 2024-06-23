using AutoMapper;

namespace pdksApi.AutoMapper
{
    public abstract class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper => ObjectMapper.Mapper;
    }
}
