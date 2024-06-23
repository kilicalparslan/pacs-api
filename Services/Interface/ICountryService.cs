using ViewLibrary.Pdks.Dtos.Pdks.CountryDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ICountryService
    {
        Task<IResult> Create(CountryAddDto countryAddDto);
        Task<IResult> Delete(int id);
        Task<CountryDto> GetCountryById(int? countryId);
        Task<IList<CountryDto>> GetList();
        Task<IResult> Update(CountryUpdateDto countryUpdateDto);
    }
}
