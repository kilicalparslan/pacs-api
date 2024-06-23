using ViewLibrary.Pdks.Dtos.Pdks.LanguageDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ILanguageService
	{
		Task<IResult> Create(LanguageAddDto languageAddDto);
		Task<IResult> Delete(int id);
		Task<IList<LanguageDto>> GetList();
		Task<LanguageDto> GetLanguageById(int? languageId);
		Task<IResult> Update(LanguageUpdateDto languageUpdateDto);
	}
}
