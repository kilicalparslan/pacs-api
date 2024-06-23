using ViewLibrary.Pdks.Dtos.Pdks.LevelDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ILevelService
	{
		Task<IResult> Create(LevelAddDto levelAddDto);
		Task<IResult> Delete(int id);
		Task<IList<LevelDto>> GetList();
		Task<LevelDto> GetLevelById(int? levelId);
		Task<IResult> Update(LevelUpdateDto levelUpdateDto);
	}
}
