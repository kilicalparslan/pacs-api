using AutoMapper;

namespace pdksApi.AutoMapper
{
    public interface IAutoMapperService
    {
        IMapper Mapper { get; }
    }
}
