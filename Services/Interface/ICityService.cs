using ViewLibrary.Pdks.Dtos.Pdks.CityDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface ICityService
    {
        Task<IResult> Create(CityAddDto cityAddDto);
        Task<IResult> Delete(int id);
        Task<CityDto> GetCityById(int? cityId);
        Task<IList<CityDto>> GetList(int? countryId);
        Task<IResult> Update(CityUpdateDto cityUpdateDto);
    }
}
