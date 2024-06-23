using ViewLibrary.Pdks.Dtos.Pdks.TitleDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ITitleService
	{
		Task<IResult> Create(TitleAddDto titleAddDto);
		Task<IResult> Delete(int id);
		Task<IList<TitleDto>> GetList();
		Task<TitleDto> GetTitleById(int? titleId);
		Task<IResult> Update(TitleUpdateDto titleUpdateDto);
	}
}
