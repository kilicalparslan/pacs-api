using pdksApi.Core.Utilities.Results;
using ViewLibrary.Pdks.Dtos.Pdks.CountyDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface ICountyService
    {
        Task<IResult> Create(CountyAddDto countyAddDto);
        Task<IResult> Delete(int id);
        Task<CountyDto> GetCountyById(int? countyId);
        Task<IList<CountyDto>> GetList(int? cityId);
        Task<IResult> Update(CountyUpdateDto countyUpdateDto);
    }
}
